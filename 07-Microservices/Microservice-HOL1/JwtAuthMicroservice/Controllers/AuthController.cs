using JwtAuthMicroservice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public sealed class AuthController(IOptions<JwtOptions> jwtOptions) : ControllerBase
{
    // Demo-only in-memory users. Replace this with a database and hashed passwords in production.
    private static readonly List<User> Users =
    [
        new User { Id = 1, Username = "kavya", Password = "Password@123" },
        new User { Id = 2, Username = "demo", Password = "Demo@123" }
    ];

    [HttpPost("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<TokenResponse> Login([FromBody] LoginModel model)
    {
        var user = Users.SingleOrDefault(user =>
            user.Username.Equals(model.Username, StringComparison.OrdinalIgnoreCase) &&
            user.Password == model.Password);

        if (user is null)
        {
            return Unauthorized(new { message = "Invalid username or password." });
        }

        var options = jwtOptions.Value;
        var expiresAt = DateTime.UtcNow.AddMinutes(options.DurationInMinutes);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
        };
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
        var token = new JwtSecurityToken(
            issuer: options.Issuer,
            audience: options.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));

        return Ok(new TokenResponse(
            new JwtSecurityTokenHandler().WriteToken(token),
            expiresAt,
            user.Username));
    }
}

public sealed record TokenResponse(string Token, DateTime ExpiresAtUtc, string Username);
