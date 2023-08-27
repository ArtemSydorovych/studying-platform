using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Courses;

public interface ICourseRepository
{
    IEnumerable<Models.Course> GetAll();
    Models.Course GetById(Guid id);
    void Add(CourseDto course);
    void Update(Guid id, CourseDto course);
    void Delete(Guid id);
}