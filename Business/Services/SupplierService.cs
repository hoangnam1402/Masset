using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.SupplierDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IBaseRepository<Supplier> _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IBaseRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<SupplierDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var query = SupplierFilter(
                _supplierRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await query
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<SupplierDto>>(result.Items);

            return new PagedResponseModel<SupplierDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var result = await _supplierRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<SupplierDto>(result);
            return null;
        }

        public async Task<IList<SupplierDto>> GetAll()
        {
            var result = await _supplierRepository.GetAll();
            result = result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<SupplierDto>>(result);
        }

        public async Task<SupplierDto?> CreateAsync(SupplierCreateDto createRequest)
        {
            var supplier = _mapper.Map<Supplier>(createRequest);

            supplier.IsDeleted = false;
            supplier.CreateDay = supplier.UpdateDay = DateTime.Now;

            var result = await _supplierRepository.Add(supplier);
            if (result != null)
            {
                return _mapper.Map<SupplierDto>(supplier);
            }
            return null;
        }

        public async Task<SupplierDto?> UpdateAsync(int id, SupplierUpdateDto updateRequest)
        {
            var supplier = await _supplierRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
                return null;
            supplier = _mapper.Map(updateRequest, supplier);
            supplier.UpdateDay = DateTime.Now;

            var result = await _supplierRepository.Update(supplier);

            if (result != null)
                return _mapper.Map<SupplierDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _supplierRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (supplier == null)
                return false;
            supplier.IsDeleted = true;
            supplier.UpdateDay = DateTime.Now;

            var result = await _supplierRepository.Update(supplier);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _supplierRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _supplierRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _supplierRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<Supplier> SupplierFilter(
            IQueryable<Supplier> query,
            BaseQueryCriteria baseQueryCriteria)
        {
            if (!string.IsNullOrEmpty(baseQueryCriteria.Search))
            {
                query = query.Where(b =>
                    (b.Name != null && b.Name.Contains(baseQueryCriteria.Search)) ||
                    (b.Email != null && b.Email.Contains(baseQueryCriteria.Search)) ||
                    (b.Phone != null && b.Phone.Contains(baseQueryCriteria.Search)) ||
                    (b.City != null && b.City.Contains(baseQueryCriteria.Search)) ||
                    (b.Country != null && b.Country.Contains(baseQueryCriteria.Search)) ||
                    (b.Address != null && b.Address.Contains(baseQueryCriteria.Search))
                    );
            }

            //not showing deleted
            query = query.Where(x => x.IsDeleted == false);

            return query;
        }

        #endregion

    }
}
