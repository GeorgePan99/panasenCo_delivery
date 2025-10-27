using Microsoft.AspNetCore.Mvc;
using Entrance.Models;
using Entrance.DTO;
using Microsoft.AspNetCore.Identity;

namespace Entrance.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController: Controller
{
    private readonly UserManager<User> _userManager;
    
    public AuthController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        if (await _userManager.FindByEmailAsync(dto.Email) != null)
            return BadRequest("User with this email already exists");

        User user = new User
        {
            Name = dto.Name,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (result.Succeeded)
            return Ok("User created");
        
        return BadRequest(result.Errors);
    }
}