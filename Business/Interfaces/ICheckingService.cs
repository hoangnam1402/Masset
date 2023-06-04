using Contracts;
using Contracts.Dtos.CheckingDtos;

namespace Business.Interfaces
{
    public interface ICheckingService
    {
        Task<PagedResponseModel<CheckingDto>> GetByPageAssetAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<CheckingDto>> GetByPageComponentAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<PagedResponseModel<CheckingDto>> GetByComponentAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, int id);
        Task<PagedResponseModel<CheckingDto>> GetHistoryOfAssetAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, int id);
        Task<PagedResponseModel<CheckingDto>> GetByAssetOfComponentAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, int id);
        Task<CheckingDto?> CreateAsync(CheckingCreateDto createRequest);
        Task<CheckingDto?> UpdateAsync(int id, CheckingUpdateDto updateRequest);
        Task<CheckingDto?> DeleteAsync(CheckingUpdateDto updateRequest);
    }
}
