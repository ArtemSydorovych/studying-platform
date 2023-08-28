
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Repositories;

public interface IStudentRepository
{
    Task Add(UserDto user);
    IEnumerable<Student> GetAll();
    Task<Student> GetById(Guid id);
    Task UpdateEmail(Guid id, string email);
    Task UpdatePassword(Guid id, string currentPassword, string newPassword);
    Task Delete(Guid id);
    Task SetMentor(Guid userId, Guid mentorId);
}