using Contracts;
using Contracts.Dtos.DepreciationDtos;

namespace Business.Interfaces
{
    public interface IDepreciationService
    {
        Task<PagedResponseModel<DepreciationDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<DepreciationDto?> GetByIdAsync(int id);
        Task<DepreciationDto?> CreateAsync(DepreciationCreateDto createRequest);
        Task<DepreciationDto?> UpdateAsync(int id, DepreciationUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsDelete(int id);
        Task<DepreciationDto?> GetOfAssetAsync(int id);
        Task<DepreciationDto?> GetOfComponentAsync(int id);
    }
}
