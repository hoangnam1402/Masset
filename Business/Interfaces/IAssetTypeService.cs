using Contracts;
using Contracts.Dtos.AssetTypeDtos;

namespace Business.Interfaces
{
    public interface IAssetTypeService
    {
        Task<PagedResponseModel<AssetTypeDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<IList<AssetTypeDto>> GetAll();
        Task<AssetTypeDto?> GetByIdAsync(int id);
        Task<AssetTypeDto?> CreateAsync(AssetTypeCreateDto createRequest);
        Task<AssetTypeDto?> UpdateAsync(int id, AssetTypeUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);

    }
}
