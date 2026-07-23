using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToken()
        {
            var token = GenerateJSONWebToken(1, "Admin");

            return Ok(token);
        }

        private string GenerateJSONWebToken(int userId, string role)
        {
            var securityKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("ThisIsMySecretKeyForJwtAuthentication12345"));

            var credentials =
                new SigningCredentials(
                    securityKey,
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("UserId", userId.ToString())
            };

            var token =
                new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}