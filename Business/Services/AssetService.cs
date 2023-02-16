using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.AssetDtos;
using DataAccess.Entities;
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

            var assets = await assetQuery
                .AsNoTracking()
                .Include("Type")
                .Include("Supplier")
                .Include("Location")
                .Include("Brand")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<AssetDto>>(assets.Items);

            return new PagedResponseModel<AssetDto>
            {
                CurrentPage = assets.CurrentPage,
                TotalPages = assets.TotalPages,
                TotalItems = assets.TotalItems,
                Items = dtos
            };
        }

        public async Task<AssetDto> CreateAsync(AssetCreateAndUpdateDto assetCreateRequest)
        {
            assetCreateRequest.IsDelete = false;

            var newAsset = _mapper.Map<Asset>(assetCreateRequest);
            var result = await _assetRepository.Add(newAsset);
            if (result != null)
            {
                return _mapper.Map<AssetDto>(newAsset);
            }
            return null;
        }

        public async Task<AssetDto> UpdateAsync(int id, AssetCreateAndUpdateDto assetUpdateRequest)
        {
            var asset = await _assetRepository.Entities
                .FirstOrDefaultAsync(x => x.Id==id);

            asset = _mapper.Map<AssetCreateAndUpdateDto, Asset>(assetUpdateRequest, asset);

            var assetUpdated = await _assetRepository.Update(asset);

            var assetUpdatedDTO = _mapper.Map<AssetDto>(assetUpdated);

            return assetUpdatedDTO;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var asset = await _assetRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            //if (asset == null)
            //{
            //    throw new NotFoundException("Not Found!");
            //}
            //if (asset.State == AssetStateEnum.Assigned)
            //{
            //    throw new ErrorException("Cannot delete when state asset is assigned");
            //}
            //if (asset.IsDeleted == true)
            //{
            //    throw new ErrorException("Asset has been deleted before");
            //}
            asset.IsDelete = true;

            var assetDelete = await _assetRepository.Update(asset);

            return assetDelete!=null;
        }

        #region Private Method
        private IQueryable<Asset> AssetFilter(
            IQueryable<Asset> assetQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!String.IsNullOrEmpty(baseQueryCriteria.Search))
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
            assetQuery = assetQuery.Where(x => x.IsDelete==false);

            return assetQuery;
        }

        #endregion
    }
}
