
using Utvikler_portal.JobSeekerModul.Services.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.DTOs;

namespace Utvikler_portal.Shared.Controllers
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


        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [HttpGet("GetUser", Name = "GetUsersId")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User couldn't find");
            }
            return Ok(user);
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserRegDTO userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.CreateUserAsync(userDto);

            if (createdUser == null)
            {
                return NotFound("Failed to create user or error occurred.");
            }

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }



        [HttpPut("UpdateUser", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToUpdate = await _userService.GetUserByIdAsync(id);
            if (userToUpdate == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.UpdateUserAsync(id);

            return NoContent();
        }

    
        [HttpDelete("DeleteUser", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var userToDelete = await _userService.GetUserByIdAsync(id);
            if (userToDelete == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            await _userService.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
