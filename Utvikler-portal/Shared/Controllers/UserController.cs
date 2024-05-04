using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;

namespace Utvikler_portal.Shared.Controllers;

[Route("[controller]")]
[ApiController, Authorize]
public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)

    {
        _userService = userService;
    }

    [HttpGet("GetAllUsers", Name = "GetAllUsers")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers(int pageNr = 1, int pageSize = 10, string sortBy = "defaultSortProperty")
    {
        return Ok(await _userService.GetAllUsersAsync(pageNr, pageSize, sortBy));
    }

    [HttpGet("GetUser", Name = "GetUserId")]
    public async Task<ActionResult<UserDTO>> GetUserByIdAsync(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound($"User with ID {id} not found.");

        return Ok(user);
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<UserDTO>> CreateUserAsync(UserDTO dTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        };

        var user = await _userService.CreateUserAsync(dTO);


        if (user == null)
            return NotFound("Failed to create user or error occurred.");

        return Ok(user);
    }

    [Authorize(Policy = "userIdPolicy")]
    [HttpPut("UpdateUser={userId:Guid}", Name = "UpdateUser")]
    public async Task<ActionResult<UserDTO>> UpdateUserAsync(Guid id, UserDTO dTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        var user = await _userService.UpdateUserAsync(id, dTO);
        if (user == null)

            return NotFound($"User with ID {id} not found.");

        return Ok(user);
    }

    [Authorize(Policy = "userIdPolicy")]
    [HttpDelete("DeleteUser={userId:Guid}", Name = "DeleteUser")]
    public async Task<ActionResult<UserDTO>> DeleteUserAsync(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userService.DeleteUserAsync(id);

        if (user == null)
            return NotFound($"User with ID {id} not found.");

        return Ok(user);
    }
}