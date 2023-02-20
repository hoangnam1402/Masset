using Contracts;
using Contracts.Dtos;
using Contracts.Dtos.EmployeeDtos;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<PagedResponseModel<EmployeeDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<EmployeeDto> CreateAsync(EmployeeCreateDto createRequest);
        Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto updateRequest);
        Task<EmployeeDto> LoginEmployee(LoginDto loginRequest);
        Task<bool> ChangePassword(Guid id, EmployeeDto employeeDto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> IsExist(Guid id);
        Task<bool> IsExist(string userName);
        Task<bool> IsDelete(Guid id);
        Task<bool> LoginFail(LoginDto loginRequest);
    }
}
