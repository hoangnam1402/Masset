using Contracts.Dtos;
using Contracts.Dtos.EmployeeDtos;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployee(EmployeeCreateDto employeeCreateRequest);
        Task<EmployeeDto> LoginEmployee(LoginDto loginRequest);
        Task<bool> IsExist(Guid id);
        Task<bool> IsExist(string userName);
        Task<bool> LoginFail(LoginDto loginRequest);
    }
}
