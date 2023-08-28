namespace VanyaTeach.User.Data.Models;

public abstract class User
{
    public Guid Id = Guid.NewGuid();
    public required string Name;
}