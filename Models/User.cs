namespace JwtAspNet.Models;

public record User(int Id, string Email, string Password, string Name, string[] Roles);