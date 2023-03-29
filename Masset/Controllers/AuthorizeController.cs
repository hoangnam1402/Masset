using Contracts.Constants;
using Contracts.Dtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Entities;
using Masset.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;

        public AuthorizeController(UserManager<User> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost]
        public async Task<UserResponseDto> Login([FromBody] LoginDto userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.UserName) || string.IsNullOrEmpty(userRequest.Password))
            {
                var error = "Username and password is required.";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            if (!await _authService.ValidateUser(userRequest))
            {
                var error = "Username or password is incorrect. Please try again";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            User user = await _userManager.FindByNameAsync(userRequest.UserName);
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _authService.CreateToken();

            UserResponseDto result = new UserResponseDto()
            {
                Token = token,
                Id = user.Id,
                UserName = user.UserName,
                Role = roles[0],
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                FirstLogin = user.FirstLogin,
                Error = false,
                Message = "",
            };
            return result;

        }

        [HttpGet("me")]
        [Authorize]
        public async Task<UserResponseDto> Me()
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var username = claimsDictionary[UserClaims.UserName];
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);

            UserResponseDto result = new UserResponseDto()
            {
                Token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""),
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = roles[0],
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                FirstLogin = user.FirstLogin,
                Error = false,
                Message = "",
            };

            return result;
        }

        [HttpPut]
        [Authorize]
        public async Task<UserResponseDto> ChangePassword([FromBody] ChangePasswordDto userRequest)
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }
            var username = claimsDictionary[UserClaims.UserName];
            if (!await _authService.ValidateUser(new LoginDto
            {
                UserName = username,
                Password = userRequest.CurrentPassword
            }))
            {
                var error = "Password is incorrect. Please try again";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            //fix same password issue
            var user = await _userManager.FindByNameAsync(username);
            var samePassword = await _userManager.CheckPasswordAsync(user, userRequest.NewPassword);
            if (samePassword)
            {
                var error = "The new password cannot be the same as the old password";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }

            var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var changePassword = await _userManager.ResetPasswordAsync(user, passwordToken, userRequest.NewPassword);

            if (changePassword.Succeeded)
            {
                user.FirstLogin = false;
                await _userManager.UpdateAsync(user);
                var roles = await _userManager.GetRolesAsync(user);

                UserResponseDto result = new UserResponseDto()
                {
                    Token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", ""),
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = roles[0],
                    PhoneNumber = user.PhoneNumber,
                    IsActive = user.IsActive,
                    FirstLogin = user.FirstLogin,
                    Error = false,
                    Message = "",
                };

                return result;
            }
            else
            {
                var error = "Failed to change user password";
                return new UserResponseDto
                {
                    Error = true,
                    Message = error,
                };
            }
        }
    }
}
