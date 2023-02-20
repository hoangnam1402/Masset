using Contracts;
using Contracts.Dtos.AssetDtos;

namespace Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<AssetDto> GetByTagAsync(string tag);
        Task<AssetDto> GetByIdAsync(int id);
        Task<AssetDto> CreateAsync(AssetCreateDto createRequest);
        Task<AssetDto> UpdateAsync(int id, AssetUpdateDto updateRequest);
        Task<AssetDto> UpdateAsync(string tag, AssetUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string tag);
        Task<bool> IsDelete(int id);
        Task<bool> IsDelete(string tag);
    }
}
