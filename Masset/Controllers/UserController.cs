using Business.Interfaces;
using Contracts;
using Contracts.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize]
        public async Task<IActionResult> GetUsers(
            [FromQuery] BaseQueryCriteria baseQueryCriteria,
            CancellationToken cancellationToken)
        {

            var userResponses = await _userService.GetByPageAsync(
                                            baseQueryCriteria,
                                            cancellationToken);
            return Ok(userResponses);
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Not found user with id: " + id);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.UserName))
            {
                return BadRequest("Username is required");
            }
            else
            {
                var result = await _userService.RegisterUser(userRequest);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(
            [FromRoute] int id,
            [FromBody] UserUpdateDto userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.UserName))
            {
                return BadRequest("Username and Status is required");
            }

            if (!await _userService.IsExist(id))
                return BadRequest("Id not exist");

            var updatedUser = await _userService.UpdateAsync(id, userRequest);

            return Ok(updatedUser);
        }

    }
}
