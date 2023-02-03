using Contracts.Dtos.EmployeeDtos;

namespace Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployee(EmployeeCreateDto employeeCreateRequest);
        Task<EmployeeDto> LoginEmployee(EmployeeLoginDto employeeLoginRequest);
    }
}
