using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Homeworks;

public interface IHomeworkDescriptionRepository
{
    HomeworkDescription GetById(Guid id);
    void Add(HomeworkDescriptionDto homework);
    void Update(Guid id, HomeworkDescriptionDto homework);
    void Delete(Guid id); 
}