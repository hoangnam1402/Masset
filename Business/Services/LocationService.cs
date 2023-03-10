using AutoMapper;
using Business.Extensions;
using Business.Interfaces;
using Contracts;
using Contracts.Dtos.LocationDtos;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class LocationService : ILocationService
    {
        private readonly IBaseRepository<Location> _locationRepository;
        private readonly IMapper _mapper;

        public LocationService(IBaseRepository<Location> locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseModel<LocationDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria,
                                                                    CancellationToken cancellationToken)
        {
            var query = LocationFilter(
                _locationRepository.Entities.AsQueryable(),
                baseQueryCriteria);

            var result = await query
                .AsNoTracking()
                .PaginateAsync(
                    baseQueryCriteria,
                    cancellationToken);

            var dtos = _mapper.Map<IList<LocationDto>>(result.Items);

            return new PagedResponseModel<LocationDto>
            {
                CurrentPage = result.CurrentPage,
                TotalPages = result.TotalPages,
                TotalItems = result.TotalItems,
                Items = dtos
            };
        }

        public async Task<LocationDto?> GetByIdAsync(int id)
        {
            var result = await _locationRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result != null)
                return _mapper.Map<LocationDto>(result);
            return null;
        }

        public async Task<IList<LocationDto>> GetAll()
        {
            var result = await _locationRepository.GetAll();
            result.Where(x => x.IsDeleted == false);
            return _mapper.Map<IList<LocationDto>>(result);
        }

        public async Task<LocationDto?> CreateAsync(LocationCreateDto createRequest)
        {
            var location = _mapper.Map<Location>(createRequest);

            location.IsDeleted = false;
            location.CreateDay = location.UpdateDay = DateTime.Now;

            var result = await _locationRepository.Add(location);
            if (result != null)
            {
                return _mapper.Map<LocationDto>(location);
            }
            return null;
        }

        public async Task<LocationDto?> UpdateAsync(int id, LocationUpdateDto updateRequest)
        {
            var location = await _locationRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (location == null)
                return null;
            location = _mapper.Map(updateRequest, location);
            location.UpdateDay = DateTime.Now;

            var result = await _locationRepository.Update(location);

            if (result != null)
                return _mapper.Map<LocationDto>(result);
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await _locationRepository.Entities
                .FirstOrDefaultAsync(x => x.Id == id);
            if (location == null)
                return false;
            location.IsDeleted = true;
            location.UpdateDay = DateTime.Now;

            var result = await _locationRepository.Update(location);

            return result!=null;
        }

        public async Task<bool> IsDelete(int id)
        {
            var result = await _locationRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null && result.IsDeleted)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(int id)
        {
            if (await _locationRepository.Entities.FirstOrDefaultAsync(x => x.Id == id) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> IsExist(string name)
        {
            if (await _locationRepository.Entities.FirstOrDefaultAsync(x => x.Name == name) != null)
                return true;
            else
                return false;
        }

        #region Private Method
        private IQueryable<Location> LocationFilter(
            IQueryable<Location> query,
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
