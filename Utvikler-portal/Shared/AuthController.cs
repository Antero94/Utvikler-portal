using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.Auth.DTO;
using Utvikler_portal.Auth.Services;

namespace Utvikler_portal.Shared;

public class AuthController : Controller
{
    private readonly IMemberService _memberService;

    public AuthController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register([FromBody] RegisterMemberRequest request)
    {
        try
        {
            var response=await _memberService.RegisterMember(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
    [HttpPost("login")]

    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        try
        {
            var response=await _memberService.Login(request);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}