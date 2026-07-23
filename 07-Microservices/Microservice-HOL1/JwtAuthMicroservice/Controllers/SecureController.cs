using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SecureController : ControllerBase
{
    [HttpGet("data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        return Ok(new
        {
            message = "This is protected data.",
            authenticatedUser = User.Identity?.Name,
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
        });
    }
}
