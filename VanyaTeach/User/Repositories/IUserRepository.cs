using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public interface IUserRepository
{
    void AddUser(UserDto user);
    IEnumerable<Data.Models.User> GetAll();
    Data.Models.User GetById(Guid id);
    void Update(Guid id, UserDto user);
    void Delete(Guid id);
    void SetMentor(Guid userId, Guid mentorId);
}