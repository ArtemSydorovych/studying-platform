using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.Course.Data.Repositories.Courses;

public interface ICourseRepository
{
    IEnumerable<Models.Course> GetAll();
    Models.Course GetById(Guid id);
    void Add(Models.Course course);
    void Update(Models.Course course);
    void Delete(Guid id);
    void AddModule(LessonsModule module);
    IEnumerable<LessonsModule> GetModules(Guid courseId);
    LessonsModule GetModuleById(Guid moduleId);
    void UpdateModule(LessonsModule module);
    void DeleteModule(Guid moduleId);
}