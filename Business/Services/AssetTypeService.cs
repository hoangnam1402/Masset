using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetTypeDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IBaseRepository<AssetType> _assetTypeRepository;
        private readonly IMapper _mapper;

        public AssetTypeService(IBaseRepository<AssetType> assetTypeRepository, IMapper mapper)
        {
            _assetTypeRepository = assetTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<AssetTypeDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var assetTypeQuery = AssetTypeFilter(
                _assetTypeRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await assetTypeQuery
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssetTypeDto>>(result.Items);

            return new PagedResponseModel<AssetTypeDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<IList<AssetTypeDto>> GetAll()
        {
            var result = await _assetTypeRepository.GetAll();
            result = result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<AssetTypeDto>>(result);
        }

        public async Task<AssetTypeDto?> GetByIdAsync(int id)
        {
            var result = await _assetTypeRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            if (result != null)
                return _mapper.Map<AssetTypeDto>(result);
            return null;
        }

        public async Task<AssetTypeDto?> CreateAsync(AssetTypeCreateDto createRequest)
        {
            var assetType = _mapper.Map<AssetType>(createRequest);

            assetType.IsDeleted = false;
            assetType.CreateDay = assetType.UpdateDay = DateTime.Now;

            var result = await _assetTypeRepository.Add(assetType);
            if (result != null)
            {
                return _mapper.Map<AssetTypeDto>(assetType);
            }
            return null;
        }

        public async Task<AssetTypeDto?> UpdateAsync(int id, AssetTypeUpdateDto updateRequest)
        {
            var assetType = await _assetTypeRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (assetType == null)
                return null;
            assetType = _mapper.Map(updateRequest, assetType);
            assetType.UpdateDay = DateTime.Now;
            var result = await _assetTypeRepository.Update(assetType);

            if (result != null)
                return _mapper.Map<AssetTypeDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var assetType = await _assetTypeRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (assetType == null)
                return false;
            assetType.IsDeleted = true;
            assetType.UpdateDay = DateTime.Now;

            var result = await _assetTypeRepository.Update(assetType);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _assetTypeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _assetTypeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _assetTypeRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<AssetType> AssetTypeFilter(
            IQueryable<AssetType> assetTypeQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                assetTypeQuery = assetTypeQuery.Where(b =>
                    (b.Name != null && b.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Description != null && b.Description.Contains(baseQueryCriteria.Search))
                    );
            }

            //not showing deleted
            assetTypeQuery = assetTypeQuery.Where(x => x.IsDeleted == false);

            return assetTypeQuery;
        }

        #endregion

    }
}
