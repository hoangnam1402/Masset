using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetDtos;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AssetService : IAssetService
    {
        private readonly IBaseRepository<Asset> _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IBaseRepository<Asset> assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<AssetDto>> GetByPageAsync(
         BaseQueryCriteria baseQueryCriteria,
         CancellationToken cancellationToken)
        {
            var assetQuery = AssetFilter(
                _assetRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await assetQuery
                .AsNoTracking()
                .Include("Type")
                .Include("Supplier")
                .Include("Location")
                .Include("Brand")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssetDto>>(result.Items);

            return new PagedResponseModel<AssetDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<IList<AssetDto>> GetAll()
        {
            var result = await _assetRepository.GetAll();
            result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<AssetDto>>(result);
        }

        public async Task<AssetDto?> CreateAsync(AssetCreateDto createRequest)
        {
            var newAsset = _mapper.Map<Asset>(createRequest);

            newAsset.CreateDay = DateTime.Now;
            newAsset.UpdateDay = DateTime.Now;
            newAsset.Status = AssetStatusEnums.ReadyToDeploy;
            newAsset.IsDeleted = false;

            var result = await _assetRepository.Add(newAsset);
            if (result != null)
            {
                return _mapper.Map<AssetDto>(newAsset);
            }
            return null;
        }

        public async Task<AssetDto?> UpdateAsync(int id, AssetUpdateDto updateRequest)
        {
            var asset = await _assetRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

            asset = _mapper.Map<AssetUpdateDto, Asset>(updateRequest, asset);

            asset.UpdateDay = DateTime.Now;

            var result = await _assetRepository.Update(asset);

            if (result != null)
                return _mapper.Map<AssetDto>(result);
            else
                return null;
        }

        public async Task<AssetDto?> UpdateAsync(string tag, AssetUpdateDto updateRequest)
        {
            var asset = await _assetRepository.Entities
                .FirstOrDefaultAsync(x => x.Tag==tag);

            asset = _mapper.Map<AssetUpdateDto, Asset>(updateRequest, asset);

            asset.UpdateDay = DateTime.Now;

            var result = await _assetRepository.Update(asset);

            if (result != null)
                return _mapper.Map<AssetDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var asset = await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            asset.IsDeleted = true;

            var result = await _assetRepository.Update(asset);

            return result!=null;
        }

        public async Task<AssetDto?> GetByTagAsync(string tag)
        {
            var result = await _assetRepository.Entities
                .Include(s => s.Supplier)
                .Include(s => s.Type)
                .Include(s => s.Location)
                .Include(s => s.Brand)
                .FirstOrDefaultAsync(x => x.Tag == tag);

            if (result != null)
                return _mapper.Map<AssetDto>(result);
            return null;
        }

        public async Task<AssetDto?> GetByIdAsync(int id)
        {
            var result = await _assetRepository.Entities
                .Include(s => s.Supplier)
                .Include(s => s.Type)
                .Include(s => s.Location)
                .Include(s => s.Brand)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<AssetDto>(result);
            return null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string tag)
        {
            if (await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Tag == tag) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsDelete(string tag)
        {
            var result = await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Tag == tag);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }


        #region Private Method
        private IQueryable<Asset> AssetFilter(
            IQueryable<Asset> assetQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                assetQuery = assetQuery.Where(b =>
                    b.Name.Contains(baseQueryCriteria.Search) ||
                    b.Tag.Contains(baseQueryCriteria.Search) ||
                    b.Type.Name.Contains(baseQueryCriteria.Search) ||
                    b.Location.Name.Contains(baseQueryCriteria.Search) ||
                    b.Brand.Name.Contains(baseQueryCriteria.Search)
                    );
            }

            //not showing deleted asset
            assetQuery = assetQuery.Where(x => x.IsDeleted == false);

            return assetQuery;
        }

        #endregion
    }
}
