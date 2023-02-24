using Contracts;
using Contracts.Dtos.LocationDtos;

namespace Business.Interfaces
{
    public interface ILocationService
    {
        Task<PagedResponseModel<LocationDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<LocationDto> GetByIdAsync(int id);
        Task<IList<LocationDto>> GetAll();
        Task<LocationDto> CreateAsync(LocationCreateDto createRequest);
        Task<LocationDto> UpdateAsync(int id, LocationUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);
    }
}
