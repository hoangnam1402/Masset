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
        private User? _user;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
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

        private async Task<List<Claim>> GetClaims()
        {
            if (_user != null)
            {
                var roles = await _userManager.GetRolesAsync(_user);
                var claims = new List<Claim>
                {
                    new Claim(UserClaims.UserName,_user.UserName),
                    new Claim(UserClaims.Id,_user.Id),
                    new Claim(UserClaims.IsActive,_user.IsActive.ToString()),
                    new Claim(UserClaims.Role,roles[0])
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                return claims;
            }
            return new List<Claim> { };
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
