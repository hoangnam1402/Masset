using Contracts;
using Contracts.Dtos.DepartmentDtos;

namespace Business.Interfaces
{
    public interface IDepartmentService
    {
        Task<PagedResponseModel<DepartmentDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<DepartmentDto> GetByIdAsync(int id);
        Task<IList<DepartmentDto>> GetAll();
        Task<DepartmentDto> CreateAsync(DepartmentCreateDto createRequest);
        Task<DepartmentDto> UpdateAsync(int id, DepartmentUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);

    }
}
