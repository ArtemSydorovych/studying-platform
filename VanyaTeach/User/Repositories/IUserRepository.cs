using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public interface IUserRepository
{
    void AddUser(UserDto userDto);
    IEnumerable<UserDto> GetAll();
    UserDto GetById(Guid id);
    void Update(UserDto id);
    void Delete(Guid id);
}