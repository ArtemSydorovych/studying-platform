namespace VanyaTeach.User.Data.Models;

public class UserDto
{
    public Guid Id = Guid.NewGuid();
    public required string Name;
    public required string Email;
    public required string Password;
}