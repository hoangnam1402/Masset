using Contracts;
using Contracts.Dtos.BrandsDtos;

namespace Business.Interfaces
{
    public interface IBrandService
    {
        Task<PagedResponseModel<BrandDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<BrandDto?> GetByIdAsync(int id);
        Task<IList<BrandDto>> GetAll();
        Task<BrandDto?> CreateAsync(BrandCreateDto createRequest);
        Task<BrandDto?> UpdateAsync(int id, BrandUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);
    }
}
