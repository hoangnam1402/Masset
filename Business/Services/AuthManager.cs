using Business.Interfaces;
using Contracts.Dtos;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly SignInManager<User> _signInManager;

        public AuthManager(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> LoginUser(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, false);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
