using Contracts.Dtos;

namespace Business.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> LoginUser(LoginDto loginDto);
    }
}
