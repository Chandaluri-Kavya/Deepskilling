using System.ComponentModel.DataAnnotations;

namespace JwtAuthMicroservice.Models;

public sealed class LoginModel
{
    [Required]
    public string Username { get; init; } = string.Empty;

    [Required]
    public string Password { get; init; } = string.Empty;
}
