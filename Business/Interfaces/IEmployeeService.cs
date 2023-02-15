using Contracts;
using Contracts.Dtos;
using Contracts.Dtos.EmployeeDtos;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<PagedResponseModel<EmployeeDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<EmployeeDto> CreateAsync(EmployeeCreateDto employeeCreateRequest);
        Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto employeeUpdateRequest);
        Task<EmployeeDto> LoginEmployee(LoginDto loginRequest);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> IsExist(Guid id);
        Task<bool> IsExist(string userName);
        Task<bool> IsDelete(Guid id);
        Task<bool> LoginFail(LoginDto loginRequest);
    }
}
