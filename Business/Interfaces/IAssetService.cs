using Contracts;
using Contracts.Dtos.AssetDtos;

namespace Business.Interfaces
{
    public interface IAssetService
    {
        Task<PagedResponseModel<AssetDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, int userid);
        //Task<AssetDTO> CreateAsset(AssetCreateDTO assetCreateRequest, int userid);
        //Task<AssetDTO> UpdateAsset(int id, AssetUpdateDTO assetUpdateRequest);
        Task<bool> DeleteAsset(int id);
    }
}
