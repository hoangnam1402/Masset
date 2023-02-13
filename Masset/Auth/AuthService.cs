using Contracts.Constants;
using Contracts.Dtos;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Masset.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private User _user;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {

            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(
                JWTSettings.DurationInMinutes));

            var token = new JwtSecurityToken(
                issuer: JWTSettings.Issuer,
                claims: claims,
                expires: expiration,
                audience: JWTSettings.Audience,
                signingCredentials: signingCredentials
                );

            return token;
        }

        private List<Claim> GetClaims()
        {
            var claims = new List<Claim>
             {
                new Claim(UserClaims.UserName,_user.UserName),
                new Claim(UserClaims.Id,_user.Id.ToString()),
                new Claim(UserClaims.IsActive,_user.IsActive.ToString()),
             };

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = JWTSettings.Key;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDto loginDto)
        {
            _user = await _userManager.FindByNameAsync(loginDto.UserName);

            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, true, false);
            return result.Succeeded;
        }
    }
}
