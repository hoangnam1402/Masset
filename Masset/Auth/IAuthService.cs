using Contracts.Dtos;

namespace Masset.Auth
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginDto loginDto);
        Task<string> CreateToken();
    }
}
