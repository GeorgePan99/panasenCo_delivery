using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entites;
using UseCases.Dtos;
using UseCases.Enterfaces;

namespace Representation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto dto)
    {
        User newUser = new User {
            UserName = dto.UserName,
            Email = dto.Email
        };
        await _userService.CreateAsync(newUser, dto.PasswordHash);
        return Ok();
    }
}