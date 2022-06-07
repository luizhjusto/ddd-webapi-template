using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Api.ApplicationCore.Dto;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int id)
        {
            return Ok(await _userService.GetUserByIdAsync(id));
        }

        /// <summary>
        /// Create an user
        /// </summary>
        /// <param name="user">User's data</param>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserBaseDto user)
        {
            await _userService.CreateUserAsync(user);
            return Created("", null);
        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="id">User id</param>
        [HttpPut("{id}")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UserBaseDto user)
        {
            await _userService.UpdateUserAsync(id, user);
            return Created("", null);
        }

        /// <summary>
        /// Delete an user
        /// </summary>
        /// <param name="id">User id</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
