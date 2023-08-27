using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Lessons;

public interface ILessonRepository
{
    IEnumerable<Lesson> GetAll(Guid moduleId);
    Lesson GetById(Guid id);
    void Add(LessonDto course);
    void Update(Guid id, LessonDto course);
    void Delete(Guid id);
}