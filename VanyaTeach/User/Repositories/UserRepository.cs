using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public class UserRepository(UserContext context) : IUserRepository
{
    public void AddUser(UserDto user)
    {
        var newUser = new Data.Models.User {
            Id = user.Id,
            Name = user.Name,
        };
        context.Users.Add(newUser);
        context.SaveChanges();
    }

    public IEnumerable<Data.Models.User> GetAll() =>
        context.Users.ToList();

    public Data.Models.User GetById(Guid id) =>
        context.Users.Find(id)!;

    public void Update(Guid id, UserDto user)
    {
        var userToUpdate = context.Users.FirstOrDefault(x => x.Id == id);
        if (userToUpdate is null) return;
        userToUpdate.Name = user.Name;
        
        context.Users.Update(userToUpdate);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var userDto = context.Users.Find(id);
        if (userDto == null) return;

        context.Users.Remove(userDto);
        context.SaveChanges();
    }

    public void SetMentor(Guid userId, Guid mentorId)
    {
        var userToUpdate = context.Users.FirstOrDefault(x => x.Id == userId);
        if (userToUpdate is null) return;
        userToUpdate.MentorId = mentorId;
        
        context.Users.Update(userToUpdate);
    }
}