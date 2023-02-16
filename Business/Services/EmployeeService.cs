using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos;
using Contracts.Dtos.EmployeeDtos;
using DataAccess.Entities;
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

        public async Task<EmployeeDto> CreateAsync(EmployeeCreateDto employeeCreateRequest)
        {
            Guid id = Guid.NewGuid();
            var newEmployee = _mapper.Map<Employee>(employeeCreateRequest);
            newEmployee.Id = id;
            newEmployee.IsDelete = false;

            var result = await _employeeRepository.Add(newEmployee);
            if (result != null)
            {
                return _mapper.Map<EmployeeDto>(newEmployee);
            }
            return null;
        }

        public async Task<EmployeeDto> LoginEmployee(LoginDto employeeLoginRequest)
        {
            var result = await _employeeRepository.Entities
                .FirstOrDefaultAsync(x => x.UserName == employeeLoginRequest.UserName 
                && x.Password == employeeLoginRequest.Password);
            return _mapper.Map<EmployeeDto>(result); ;
        }

        public async Task<bool> LoginFail(LoginDto employeeDto)
        {
            var result = await _employeeRepository.Entities
                .FirstOrDefaultAsync(x => x.UserName == employeeDto.UserName
                && x.Password == employeeDto.Password);

            if (result == null)
                return true;
            return false;
        }

        public async Task<bool> IsExist(Guid id)
        {
            if (await _employeeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }
        public async Task<bool> IsDelete(Guid id)
        {
            var result = await _employeeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDelete)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string userName)
        {
            if (await _employeeRepository.Entities.FirstOrDefaultAsync(x => x.UserName == userName) != null)
                return true;
            else
                return false;
        }

        public async Task<PagedResponseModel<EmployeeDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken)
        {
            var employeeQuery = EmployeeFilter(
                _employeeRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var employees = await employeeQuery
                .AsNoTracking()
                .Include("Department")
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<EmployeeDto>>(employees.Items);

            return new PagedResponseModel<EmployeeDto>
            {
                CurrentPage = employees.CurrentPage,
                TotalPages = employees.TotalPages,
                TotalItems = employees.TotalItems,
                Items = dtos
            };
        }

        public async Task<EmployeeDto> UpdateAsync(Guid id, EmployeeUpdateDto employeeUpdateRequest)
        {
            var employee = await _employeeRepository.Entities
                .Include(s => s.Department)
                .FirstOrDefaultAsync(x => x.Id==id);

            employee = _mapper.Map<EmployeeUpdateDto, Employee>(employeeUpdateRequest, employee);

            var result = await _employeeRepository.Update(employee);

            if (result == null)
                return null;
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _employeeRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

            employee.IsDelete = true;

            var result = await _employeeRepository.Update(employee);

            return result!=null;
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var result = await _employeeRepository.Entities
                .Include(s => s.Department)
                .FirstOrDefaultAsync(x => x.Id==id);

            if (result == null)
                return null;
            return _mapper.Map<EmployeeDto>(result);

        }

        public async Task<bool> ChangePassword(Guid id, EmployeeDto employeeDto)
        {
            var employee = await _employeeRepository.Entities
                .Include(s => s.Department)
                .FirstOrDefaultAsync(x => x.Id==id);

            employee = _mapper.Map<EmployeeDto, Employee>(employeeDto, employee);

            var result = await _employeeRepository.Update(employee);

            return result!=null;
        }


        #region Private Method
        private IQueryable<Employee> EmployeeFilter(
            IQueryable<Employee> employeeQuery,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!String.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                employeeQuery = employeeQuery.Where(b =>
                    b.UserName.Contains(baseQueryCriteria.Search) ||
                    b.Email.Contains(baseQueryCriteria.Search) ||
                    b.JobRole.Contains(baseQueryCriteria.Search) ||
                    b.Phone.Contains(baseQueryCriteria.Search) ||
                    b.Department.Name.Contains(baseQueryCriteria.Search)
                    );
            }

            //not showing deleted asset
            //employeeQuery = employeeQuery.Where(x => x.IsDeleted==false);

            return employeeQuery;
        }

        #endregion

    }
}
