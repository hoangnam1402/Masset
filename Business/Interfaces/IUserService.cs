using Contracts;
using Contracts.Dtos.UserDtos;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> RegisterUser(UserCreateDto userRequest);
        Task<PagedResponseModel<UserDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken, string id);
        Task<UserDto?> GetById(string id);
        Task<UserDto?> UpdateAsync(string id, UserUpdateDto userRequest);
        Task<bool> DisableUserAsync(string id, string role);
        Task<bool> IsExist(int id);
        Task<bool> IsActive(string id);
        Task<bool> IsExist(string userName);
    }
}
