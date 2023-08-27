using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Courses;

public interface ICourseRepository
{
    IEnumerable<Models.Course> GetAll();
    Models.Course GetById(Guid id);
    void Add(CourseDto course);
    void Update(Guid id, CourseDto course);
    void Delete(Guid id);
    void AddModule(LessonModuleDto module);
    IEnumerable<LessonsModule> GetModules(Guid courseId);
    LessonsModule GetModuleById(Guid moduleId);
    void UpdateModule(Guid id, LessonModuleDto module);
    void DeleteModule(Guid moduleId);
}