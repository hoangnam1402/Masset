using AutoMapper;
using Business.Interfaces;
using Contracts.Dtos.EmployeeDtos;
using Contracts.Exceptions;
using DataAccess.Data;
using DataAccess.Entities;
using EnsureThat;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IBaseRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository=employeeRepository;
            _mapper=mapper;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeCreateDto employeeCreateRequest)
        {
            Ensure.Any.IsNotNull(employeeCreateRequest);

            var newEmployee = _mapper.Map<Employee>(employeeCreateRequest);

            var result = await _employeeRepository.Add(newEmployee);
            if (result != null)
            {
                return _mapper.Map<EmployeeDto>(newEmployee);
            }
            return null;
        }

        public async Task<EmployeeDto> LoginEmployee(EmployeeLoginDto employeeLoginRequest)
        {
            Ensure.Any.IsNotNull(employeeLoginRequest);

            var result = await _employeeRepository.Entities
                .FirstOrDefaultAsync(x => x.UserName == employeeLoginRequest.UserName 
                && x.Password == employeeLoginRequest.Password);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<EmployeeDto>(result); ;
        }

    }
}
