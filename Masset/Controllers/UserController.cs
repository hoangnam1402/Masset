using Business.Interfaces;
using Contracts;
using Contracts.Constants;
using Contracts.Dtos;
using Contracts.Dtos.UserDtos;
using DataAccess.Enums;
using Masset.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Masset.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetByPage(
            [FromQuery] BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken)
        {
            var userid = GetUserId();

            var userResponses = await _userService.GetByPageAsync(
                                            baseQueryCriteria,
                                            cancellationToken,
                                            userid);
            return Ok(userResponses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetById(string id)
        {
            if(!await _userService.IsExist(id))
                return BadRequest("Not User with id: " + id);

            var result = await _userService.GetById(id);

            if (result == null)
                return BadRequest("Somethink go wrong.");
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userRequest)
        {
            if(userRequest.Role == UserRoleEnums.Admin)
                return BadRequest("Can't create admin user.");
            if (!Enum.IsDefined(typeof(UserRoleEnums), userRequest.Role))
                return BadRequest("Role not exist.");
            if (string.IsNullOrEmpty(userRequest.UserName))
                return BadRequest("Username is required.");
            if (await _userService.IsExist(userRequest.UserName))
                return BadRequest("UserName is exist!!!");

            var result = await _userService.RegisterUser(userRequest);

            if (result != null)
                return Ok(result);
            else
                return BadRequest("Something go wrong.");
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] string id,
            [FromBody] UserUpdateDto userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.UserName))
                return BadRequest("Username and Status is required.");

            if (!await _userService.IsExist(id))
                return BadRequest("User not exist!!!");

            var result = await _userService.UpdateAsync(id, userRequest);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Something go wrong.");
        }

        #region Private Method
        private string GetUserId()
        {
            var claims = User.Claims.ToList();
            Dictionary<string, string> claimsDictionary = new Dictionary<string, string>();
            foreach (var claim in claims)
            {
                claimsDictionary.Add(claim.Type, claim.Value);
            }

            var userid = claimsDictionary[UserClaims.Id];

            return userid;
        }
        #endregion
    }
}
