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
        
        var result = await userManager.CreateAsync(newUser, user.Password);
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

    public Student GetById(Guid id) =>
        context.Students.Find(id)!;

    public void Update(Guid id, UserDto user)
    {
        var userToUpdate = context.Students.FirstOrDefault(x => x.Id == id);
        if (userToUpdate is null) return;
        userToUpdate.Name = user.Name;
        
        context.Students.Update(userToUpdate);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var userDto = context.Students.Find(id);
        if (userDto == null) return;

        context.Students.Remove(userDto);
        context.SaveChanges();
    }

    public void SetMentor(Guid userId, Guid mentorId)
    {
        var mentor = context.Mentors.Find(mentorId);
        var userToUpdate = context.Students.FirstOrDefault(x => x.Id == userId);
        if (userToUpdate is null) return;

        mentor!.Students!.Add(userToUpdate);
        userToUpdate.MentorId = mentorId;

        context.Students.Update(userToUpdate);
        context.Mentors.Update(mentor);
        context.SaveChanges();
    }
}