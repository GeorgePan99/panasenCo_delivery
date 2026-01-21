using Microsoft.AspNetCore.Mvc;
using Representation.Mappings;
using UseCases.Dtos;
using UseCases.Enterfaces;

namespace Representation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    private readonly IRegistration _registration;

    public AuthController(IRegistration registration)
    {
        _registration = registration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto dto)
    {
        var result = await _registration.CreateUser(dto);
        return result.ToActionResult();
    }
}