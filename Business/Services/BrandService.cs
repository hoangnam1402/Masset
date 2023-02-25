using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.BrandsDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<Brands> _brandsRepository;
        private readonly IMapper _mapper;

        public BrandService(IBaseRepository<Brands> brandsRepository, IMapper mapper)
        {
            _brandsRepository = brandsRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<BrandDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var query = BrandFilter(
                _brandsRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await query
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<BrandDto>>(result.Items);

            return new PagedResponseModel<BrandDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<BrandDto?> GetByIdAsync(int id)
        {
            var result = await _brandsRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<BrandDto>(result);
            return null;
        }

        public async Task<IList<BrandDto>> GetAll()
        {
            var result = await _brandsRepository.GetAll();
            result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<BrandDto>>(result);
        }

        public async Task<BrandDto?> CreateAsync(BrandCreateDto createRequest)
        {
            var brand = _mapper.Map<Brands>(createRequest);

            brand.IsDeleted = false;

            var result = await _brandsRepository.Add(brand);
            if (result != null)
            {
                return _mapper.Map<BrandDto>(brand);
            }
            return null;
        }

        public async Task<BrandDto?> UpdateAsync(int id, BrandUpdateDto updateRequest)
        {
            var brand = await _brandsRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return null;
            brand = _mapper.Map(updateRequest, brand);
            var result = await _brandsRepository.Update(brand);

            if (result != null)
                return _mapper.Map<BrandDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brand = await _brandsRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
                return false;
            brand.IsDeleted = true;

            var result = await _brandsRepository.Update(brand);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _brandsRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _brandsRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _brandsRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<Brands> BrandFilter(
            IQueryable<Brands> query,
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
