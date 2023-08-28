using Microsoft.AspNetCore.Identity;

namespace VanyaTeach.User.Data.Models;

public abstract class User : IdentityUser<Guid>
{
    public required string Name;
}

public enum UserRole
{
    Student,
    Mentor,
    Admin,
}