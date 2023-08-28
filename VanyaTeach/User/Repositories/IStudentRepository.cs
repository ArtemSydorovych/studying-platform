
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public interface IStudentRepository
{
    Task Add(UserDto user);
    IEnumerable<Student> GetAll();
    Student GetById(Guid id);
    void Update(Guid id, UserDto user);
    void Delete(Guid id);
    void SetMentor(Guid userId, Guid mentorId);
}