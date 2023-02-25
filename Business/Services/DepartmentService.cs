using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.DepartmentDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IBaseRepository<Department> _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IBaseRepository<Department> departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<DepartmentDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var query = DepartmentFilter(
                _departmentRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await query
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<DepartmentDto>>(result.Items);

            return new PagedResponseModel<DepartmentDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<IList<DepartmentDto>> GetAll()
        {
            var result = await _departmentRepository.GetAll();
            result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<DepartmentDto>>(result);
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var result = await _departmentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<DepartmentDto>(result);
            return null;
        }

        public async Task<DepartmentDto?> CreateAsync(DepartmentCreateDto createRequest)
        {
            var department = _mapper.Map<Department>(createRequest);

            department.IsDeleted = false;

            var result = await _departmentRepository.Add(department);
            if (result != null)
            {
                return _mapper.Map<DepartmentDto>(department);
            }
            return null;
        }

        public async Task<DepartmentDto?> UpdateAsync(int id, DepartmentUpdateDto updateRequest)
        {
            var department = await _departmentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
                return null;
            department = _mapper.Map(updateRequest, department);
            var result = await _departmentRepository.Update(department);

            if (result != null)
                return _mapper.Map<DepartmentDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _departmentRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
                return false;
            department.IsDeleted = true;

            var result = await _departmentRepository.Update(department);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _departmentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _departmentRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _departmentRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<Department> DepartmentFilter(
            IQueryable<Department> query,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                query = query.Where(b =>
                    (b.Name != null && b.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Description != null && b.Description.Contains(baseQueryCriteria.Search))
                    );
            }

            //not showing deleted
            query = query.Where(x => x.IsDeleted == false);

            return query;
        }

        #endregion

    }
}
