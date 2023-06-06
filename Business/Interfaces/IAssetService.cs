using Contracts;
using Contracts.Dtos.AssetDtos;
using Microsoft.AspNetCore.Http;

namespace Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDto>> GetByPageAsync(AssetQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<IList<AssetDto>> GetAll();
        Task<IList<AssetDto>> GetAllForDepreciation();
        Task<AssetDto?> GetByTagAsync(string tag);
        Task<AssetDto?> GetByIdAsync(int id);
        Task<AssetDto?> CreateAsync(AssetCreateDto createRequest);
        Task<AssetDto?> UpdateAsync(int id, AssetUpdateDto updateRequest);
        Task<AssetDto?> UpdateAsync(string tag, AssetUpdateDto updateRequest);
        Task<bool?> UpdateImageAsync(string tag, IFormFile image);
        Task<bool> UpdateCheckingAsync(int id);
        Task<bool> UpdateDepreciationAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string tag);
        Task<bool> IsDelete(int id);
        Task<bool> IsDelete(string tag);
    }
}
