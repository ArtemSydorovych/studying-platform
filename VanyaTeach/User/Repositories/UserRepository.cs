using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public class UserRepository(UserContext context) : IUserRepository
{
    public void AddUser(UserDto userDto)
    {
        context.Users.Add(userDto);
        context.SaveChanges();
    }

    public IEnumerable<UserDto> GetAll() =>
        context.Users.ToList();

    public UserDto GetById(Guid id) =>
        context.Users.Find(id)!;

    public void Update(UserDto userDto)
    {
        if (!context.Users.Any(u => u.Id == userDto.Id)) return;

        context.Users.Update(userDto);
        context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var userDto = context.Users.Find(id);
        if (userDto == null) return;

        context.Users.Remove(userDto);
        context.SaveChanges();
    }
}