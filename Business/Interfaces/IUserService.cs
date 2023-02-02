using Contracts.Dtos.UserDtos;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUser(UserCreateDto assetRequest);
        Task<PagedResponseModel<UserDto>> GetByPageAsync(UserQueryCriteriaDto assetQueryCriteria, CancellationToken cancellationToken, int userid);
        Task<UserDto> GetById(int id);
        Task<UserDto> UpdateAsync(int id, UserCreateDto userRequest);
    }
}
