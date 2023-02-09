using Contracts;
using Contracts.Dtos.UserDtos;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserCreateDto userRequest);
        Task<PagedResponseModel<UserDto>> GetByPageAsync(BaseQueryCriteria baseQueryCriteria, CancellationToken cancellationToken);
        Task<UserDto> GetById(int id);
        Task<UserDto> UpdateAsync(int id, UserUpdateDto userRequest);
        Task<bool> IsExist(int id);
    }
}
