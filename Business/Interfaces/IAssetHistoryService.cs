using Contracts;
using Contracts.Dtos.AssetHistoryDtos;

namespace Business.Interfaces
{
    public interface IAssetHistoryService
    {
        Task<PagedResponseModel<AssetHistoryDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<IList<AssetHistoryDto>> GetUnread();
        Task<bool> CreateAsync(AssetHistoryDto createRequest, string note);
        Task<AssetHistoryDto?> GetByIdAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> ReadAsync(int id);
    }
}
