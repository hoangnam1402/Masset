using Contracts;
using Contracts.Dtos.AssetDtos;

namespace Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<AssetDto> CreateAsync(AssetCreateAndUpdateDto assetCreateRequest);
        Task<AssetDto> UpdateAsync(int id, AssetCreateAndUpdateDto assetUpdateRequest);
        Task<bool> DeleteAsync(int id);
    }
}
