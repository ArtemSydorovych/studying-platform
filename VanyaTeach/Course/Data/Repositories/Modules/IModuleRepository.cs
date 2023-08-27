using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Modules;

public interface IModuleRepository
{
    IEnumerable<LessonsModule> GetAll();
    LessonsModule GetById(Guid id);
    void Add(LessonModuleDto module);
    void Update(Guid id, LessonModuleDto course);
    void Delete(Guid id);
}