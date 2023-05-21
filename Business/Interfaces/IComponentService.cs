using Contracts;
using Contracts.Dtos.AssetDtos;
using Contracts.Dtos.ComponentDtos;

namespace Business.Interfaces
{
    public interface IComponentService
    {
        Task<PagedResponseModel<ComponentDto>> GetByPageAsync(AssetQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<IList<ComponentDto>> GetAll();
        Task<ComponentDto?> GetByIdAsync(int id);
        Task<ComponentDto?> CreateAsync(ComponentCreateDto createRequest);
        Task<ComponentDto?> UpdateAsync(int id, ComponentUpdateDto updateRequest);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsDelete(int id);

    }
}
