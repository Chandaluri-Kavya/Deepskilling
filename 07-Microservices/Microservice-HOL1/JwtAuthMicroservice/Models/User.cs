namespace JwtAuthMicroservice.Models;

public sealed class User
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}
