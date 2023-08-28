using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public class StudentRepository(UserContext context) : IStudentRepository
{
    public void Add(UserDto user)
    {
        var newUser = new Student {
            Id = user.Id,
            Name = user.Name,
        };
        context.Students.Add(newUser);
        context.SaveChanges();
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
        var userToUpdate = context.Students.FirstOrDefault(x => x.Id == userId);
        if (userToUpdate is null) return;
        userToUpdate.MentorId = mentorId;
        
        context.Students.Update(userToUpdate);
    }
}