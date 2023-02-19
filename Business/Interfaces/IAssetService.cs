using Contracts;
using Contracts.Dtos.AssetDtos;

namespace Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<AssetDto> GetByTagAsync(string tag);
        Task<AssetDto> CreateAsync(AssetCreateDto assetCreateRequest);
        Task<AssetDto> UpdateAsync(int id, AssetUpdateDto assetUpdateRequest);
        Task<AssetDto> UpdateAsync(string tag, AssetUpdateDto assetUpdateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string tag);
        Task<bool> IsDelete(int id);
        Task<bool> IsDelete(string tag);
    }
}
