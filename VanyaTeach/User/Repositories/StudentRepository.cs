using Microsoft.AspNetCore.Identity;
using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public class StudentRepository(UserContext context, UserManager<Data.Models.User> userManager) : IStudentRepository
{
    public async Task Add(UserDto user)
    {
        var newUser = new Student {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
        
        var result = await userManager.CreateAsync(newUser, user.Password!);
        if (result.Succeeded)
        {
            // Assign roles to the user
            await userManager.AddToRolesAsync(newUser, new[] {
                UserRole.Student.ToString(),
            });
        }
    }
    
    public IEnumerable<Student> GetAll() =>
        context.Students.ToList();

    public async Task<Student> GetById(Guid id) =>
        (await context.Students.FindAsync(id))!;

    public async Task UpdateEmail(Guid id, string email)
    {
        var userToUpdate = await userManager.FindByIdAsync(id.ToString());
        if (userToUpdate == null)
        {
            return;
        }

        userToUpdate.Email = email;
        var emailUpdateResult = await userManager.UpdateAsync(userToUpdate);
        if (!emailUpdateResult.Succeeded)
        {
        }
    }

    public async Task UpdatePassword(Guid id, string currentPassword, string newPassword)
    {
        var userToUpdate = await userManager.FindByIdAsync(id.ToString());
        if (userToUpdate == null)
        {
            return;
        }

        if (!string.IsNullOrEmpty(currentPassword) && !string.IsNullOrEmpty(newPassword))
        {
            var changePasswordResult = await userManager.ChangePasswordAsync(userToUpdate, currentPassword, newPassword);
            if (!changePasswordResult.Succeeded)
            {
            }
        }
    }

    public async Task Delete(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        if (user == null) return;

        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            // Handle errors
        }
    }

    public async Task SetMentor(Guid userId, Guid mentorId)
    {
        var mentor = await context.Mentors.FindAsync(mentorId);
        var userToUpdate = context.Students.FirstOrDefault(x => x.Id == userId);
        if (userToUpdate is null) return;

        mentor!.Students!.Add(userToUpdate);
        userToUpdate.MentorId = mentorId;

        context.Students.Update(userToUpdate);
        context.Mentors.Update(mentor);
        await context.SaveChangesAsync();
    }
}