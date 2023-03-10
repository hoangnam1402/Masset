using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetHistoryDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AssetHistoryService : IAssetHistoryService
    {
        private readonly IBaseRepository<AssetHistory> _assetHistoryRepository;
        private readonly IMapper _mapper;

        public AssetHistoryService(IBaseRepository<AssetHistory> assetHistoryRepository, IMapper mapper)
        {
            _assetHistoryRepository = assetHistoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AssetHistoryDto createRequest, string note)
        {
            var assetHistory = _mapper.Map<AssetHistory>(createRequest);

            assetHistory.CreateDay = DateTime.Now;
            assetHistory.UpdateDay = DateTime.Now;
            assetHistory.Status = AssetHistoryStatusEnums.Unread;
            assetHistory.Note = note;

            var result = await _assetHistoryRepository.Add(assetHistory);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<PagedResponseModel<AssetHistoryDto>> GetByPageAsync(
         BaseQueryCriteria baseQueryCriteria,
         CancellationToken cancellationToken)
        {
            var assetQuery = _assetHistoryRepository.Entities.AsQueryable();
            baseQueryCriteria.SortOrder = (Contracts.Dtos.EnumDtos.SortOrderEnumDto)1;
            baseQueryCriteria.SortColumn = "CreateDay";

            var result = await assetQuery
                .AsNoTracking()
                .Include("Asset")
                .Include("User")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssetHistoryDto>>(result.Items);

            return new PagedResponseModel<AssetHistoryDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<IList<AssetHistoryDto>> GetUnread()
        {
            var result = await _assetHistoryRepository.GetAll();
            result.Where(x => x.Status == AssetHistoryStatusEnums.Unread);
            return _mapper.Map<IList<AssetHistoryDto>>(result);
        }

        public async Task<AssetHistoryDto?> GetByIdAsync(int id)
        {
            var result = await _assetHistoryRepository.Entities
                .Include(s => s.User)
                .Include(s => s.Asset)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<AssetHistoryDto>(result);
            return null;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _assetHistoryRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> ReadAsync(int id)
        {
            var assetHistory = await _assetHistoryRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (assetHistory == null)
                return false;

            assetHistory.Status = AssetHistoryStatusEnums.Read;
            assetHistory.UpdateDay = DateTime.Now;

            var result = await _assetHistoryRepository.Update(assetHistory);

            if (result != null)
                return true;
            else
                return false;
        }
    }
}
