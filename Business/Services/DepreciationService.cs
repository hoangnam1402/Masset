using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.DepreciationDtos;
using Contracts.Dtos.EnumDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class DepreciationService : IDepreciationService
    {
        private readonly IBaseRepository<Depreciation> _depreciatioRepository;
        private readonly IMapper _mapper;

        public DepreciationService(IBaseRepository<Depreciation> depreciationRepository, IMapper mapper)
        {
            _depreciatioRepository = depreciationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<DepreciationDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var depreciatioQuery = DepreciationFilter(
                _depreciatioRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await depreciatioQuery
                .AsNoTracking()
                .Include("Asset")
                .Include("Component")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<DepreciationDto>>(result.Items);

            return new PagedResponseModel<DepreciationDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }
        
        public async Task<DepreciationDto?> GetByIdAsync(int id)
        {
            var result = await _depreciatioRepository.Entities
                .Include(s => s.Component)
                .Include(s => s.Asset)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (result != null)
                return _mapper.Map<DepreciationDto>(result);
            return null;
        }

        public async Task<DepreciationDto?> GetOfAssetAsync(int id)
        {
            var result = await _depreciatioRepository.Entities
                .Include(s => s.Asset)
                .FirstOrDefaultAsync(x => x.AssetID == id && x.IsDeleted == false);

            if (result != null)
                return _mapper.Map<DepreciationDto>(result);
            return null;
        }

        public async Task<DepreciationDto?> GetOfComponentAsync(int id)
        {
            var result = await _depreciatioRepository.Entities
                .Include(s => s.Component)
                .FirstOrDefaultAsync(x => x.ComponentID == id);

            if (result != null)
                return _mapper.Map<DepreciationDto>(result);
            return null;
        }

        public async Task<DepreciationDto?> CreateAsync(DepreciationCreateDto createRequest)
        {
            var depreciation = _mapper.Map<Depreciation>(createRequest);

            depreciation.IsDeleted = false;
            depreciation.CreateDay = depreciation.UpdateDay = DateTime.Now;

            var result = await _depreciatioRepository.Add(depreciation);
            if (result != null)
            {
                return _mapper.Map<DepreciationDto>(depreciation);
            }
            return null;
        }

        public async Task<DepreciationDto?> UpdateAsync(int id, DepreciationUpdateDto updateRequest)
        {
            var depreciation = await _depreciatioRepository.Entities
                .Include(s => s.Asset)
                .Include(s => s.Component)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (depreciation == null)
                return null;
            depreciation = _mapper.Map(updateRequest, depreciation);
            depreciation.UpdateDay = DateTime.Now;
            var result = await _depreciatioRepository.Update(depreciation);

            if (result != null)
                return _mapper.Map<DepreciationDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var depreciation = await _depreciatioRepository.Entities
                .Include(s => s.Asset)
                .Include(s => s.Component)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (depreciation == null)
                return false;
            depreciation.IsDeleted = true;
            depreciation.UpdateDay = DateTime.Now;
            var result = await _depreciatioRepository.Update(depreciation);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _depreciatioRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _depreciatioRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<Depreciation> DepreciationFilter(
            IQueryable<Depreciation> depreciationQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                depreciationQuery = depreciationQuery.Where(b =>
                    (b.Asset != null && b.Asset.Name != null && b.Asset.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Asset != null && b.Asset.Tag != null && b.Asset.Tag.Contains(baseQueryCriteria.Search)) ||
                    (b.Component != null && b.Component.Name != null && b.Component.Name.Contains(baseQueryCriteria.Search))
                    );
            }

            if (baseQueryCriteria.SortColumn == "category")
            {
                depreciationQuery = baseQueryCriteria.SortOrder == SortOrderEnumDto.Accsending
                    ? depreciationQuery.OrderBy(p =>
                    p.Category == DepreciationCategoryEnums.Asset ? "Asset" :
                    p.Category == DepreciationCategoryEnums.Component ? "Component" :
                    "ZZZ"
                    )
                    : depreciationQuery.OrderByDescending(p =>
                    p.Category == DepreciationCategoryEnums.Asset ? "Asset" :
                    p.Category == DepreciationCategoryEnums.Component ? "Component" :
                    "ZZZ");
                baseQueryCriteria.SortColumn = null;
            }

            //not showing deleted asset
            depreciationQuery = depreciationQuery.Where(x => x.IsDeleted == false);

            return depreciationQuery;
        }

        #endregion

    }
}
