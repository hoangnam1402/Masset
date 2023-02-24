using Contracts;
using Contracts.Dtos.SupplierDtos;

namespace Business.Interfaces
{
    public interface ISupplierService
    {
        Task<PagedResponseModel<SupplierDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<SupplierDto> GetByIdAsync(int id);
        Task<IList<SupplierDto>> GetAll();
        Task<SupplierDto> CreateAsync(SupplierCreateDto createRequest);
        Task<SupplierDto> UpdateAsync(int id, SupplierUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);
    }
}
