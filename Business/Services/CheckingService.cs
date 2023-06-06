using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.CheckingDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class CheckingService : ICheckingService
    {
        private readonly IBaseRepository<Checking> _checkingRepository;
        private readonly IMapper _mapper;

        public CheckingService(IBaseRepository<Checking> checkingRepository, IMapper mapper)
        {
            _checkingRepository = checkingRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<CheckingDto>> GetByPageAssetAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken)
        {
            var result = await _checkingRepository.Entities.AsQueryable()
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.Asset)
                .ThenInclude(x => x!.Location)
                .Where(x => x.Component == null)
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<CheckingDto>>(result.Items);
            return new PagedResponseModel<CheckingDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<PagedResponseModel<CheckingDto>> GetByPageComponentAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken)
        {
            var result = await _checkingRepository.Entities.AsQueryable()
                .AsNoTracking()
                .Include(s => s.Component)
                .Include(s => s.Component)
                .Include(s => s.Asset)
                .ThenInclude(x => x!.Location)
                .Where(x => x.User == null && x.Quantity > 0)
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<CheckingDto>>(result.Items);
            return new PagedResponseModel<CheckingDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<CheckingDto?> CreateAsync(CheckingCreateDto createRequest)
        {
            var checking = _mapper.Map<Checking>(createRequest);

            checking.IsEffective = true;
            checking.UpdateDay = DateTime.Now;
            checking.CreateDay = DateTime.Now;

            var result = await _checkingRepository.Add(checking);
            if (result != null)
            {
                return _mapper.Map<CheckingDto>(checking);
            }
            return null;
        }

        public async Task<PagedResponseModel<CheckingDto>> GetHistoryOfAssetAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken,
            int id)
        {
            var checkingQuery = HistoryFilter(
                            _checkingRepository.Entities.AsQueryable(),
                            baseQueryCriteria);

            var result = await checkingQuery
                .AsNoTracking()
                .Include(s => s.User)
                .Include(s => s.Asset)
                .Where(x => x.Asset != null && x.Asset.Id == id && x.Component == null)
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<CheckingDto>>(result.Items);
            return new PagedResponseModel<CheckingDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<PagedResponseModel<CheckingDto>> GetByAssetOfComponentAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken,
            int id)
        {
            var checkingQuery = ComponentByAssetFilter(
                            _checkingRepository.Entities.AsQueryable(),
                            baseQueryCriteria);

            var result = await checkingQuery
                .AsNoTracking()
                .Include(s => s.Component)
                .ThenInclude(x => x!.Type)
                .Include(s => s.Component)
                .ThenInclude(x => x!.Brand)
                .Include(s => s.Asset)
                .Where(x => x.Asset != null && x.Asset.Id == id && x.Quantity > 0 && x.IsEffective == true)
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<CheckingDto>>(result.Items);
            return new PagedResponseModel<CheckingDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<PagedResponseModel<CheckingDto>> GetByComponentAsync(
            BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken,
            int id)
        {
            var checkingQuery = ComponentByComponentFilter(
                _checkingRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await checkingQuery
                .AsNoTracking()
                .Include(s => s.Component)
                .Include(s => s.Asset)
                .Where(x => x.Component != null && x.Component.Id == id && x.Quantity > 0 && x.IsEffective == true)
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<CheckingDto>>(result.Items);
            return new PagedResponseModel<CheckingDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<CheckingDto?> UpdateAsync(int id, CheckingUpdateDto updateRequest)
        {
            var checking = await _checkingRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (checking == null)
                return null;

            checking.Quantity = checking.Quantity - updateRequest.Quantity;
            checking.UpdateDay = DateTime.Now;
            var update = await _checkingRepository.Update(checking);
            if (update == null)
                return null;

            var checkIn = _mapper.Map<Checking>(updateRequest);
            checkIn.IsEffective = false;
            checkIn.UpdateDay = DateTime.Now;
            checkIn.CreateDay = DateTime.Now;
            var result = await _checkingRepository.Add(checkIn);
            if (result != null)
                return _mapper.Map<CheckingDto>(result);
            else
                return null;
        }

        public async Task<CheckingDto?> DeleteAsync(CheckingUpdateDto updateRequest)
        {
            var checking = await _checkingRepository.Entities
                .FirstOrDefaultAsync(x => x.IsEffective == true && x.AssetID == updateRequest.AssetID);
            if (checking == null)
                return null;

            checking.UpdateDay = DateTime.Now;
            checking.IsEffective = false;

            var deleteCheking = await _checkingRepository.Update(checking);
            if (deleteCheking == null)
                return null;

            checking.Id = 0;
            checking.IsCheckOut = false;
            checking.CheckDay = updateRequest.CheckDay;
            var result = await _checkingRepository.Add(checking);

            if (result != null)
            {
                return _mapper.Map<CheckingDto>(checking);
            }
            return null;
        }

        public async Task<CheckingDto?> GetByAssetIdAsync(int id)
        {
            var result = await _checkingRepository.Entities
                .Include(s => s.Component)
                .Include(s => s.Asset)
                .FirstOrDefaultAsync(x => x.IsEffective == true && x.AssetID == id);

            if (result != null)
                return _mapper.Map<CheckingDto>(result);
            return null;
        }

        #region Private Method
        private IQueryable<Checking> HistoryFilter(
            IQueryable<Checking> checkingQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                checkingQuery = checkingQuery.Where(b =>
                    (b.Asset != null && b.Asset.Name != null && b.Asset.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.User != null && b.User.UserName != null && b.User.UserName.Contains(baseQueryCriteria.Search))
                    );
            }

            return checkingQuery;
        }

        private IQueryable<Checking> ComponentByAssetFilter(
            IQueryable<Checking> checkingQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                checkingQuery = checkingQuery.Where(b =>
                    (b.Component != null && b.Component.Name != null && b.Component.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Component != null && b.Component.Type != null && b.Component.Type.Name != null && b.Component.Type.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Component != null && b.Component.Brand != null && b.Component.Brand.Name != null && b.Component.Brand.Name.Contains(baseQueryCriteria.Search))
                    );
            }

            return checkingQuery;
        }

        private IQueryable<Checking> ComponentByComponentFilter(
            IQueryable<Checking> checkingQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                checkingQuery = checkingQuery.Where(b =>
                    (b.Asset != null && b.Asset.Name != null && b.Asset.Name.Contains(baseQueryCriteria.Search)));
            }

            return checkingQuery;
        }


        #endregion
    }
}
