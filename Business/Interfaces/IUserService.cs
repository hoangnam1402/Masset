using Contracts;
using Contracts.Dtos.UserDtos;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserCreateDto assetRequest);
        Task<PagedResponseModel<UserDto>> GetByPageAsync(BaseQueryCriteria assetQueryCriteria, CancellationToken cancellationToken);
        Task<UserDto> GetById(int id);
        Task<UserDto> UpdateAsync(int id, UserUpdateDto userRequest);
    }
}
