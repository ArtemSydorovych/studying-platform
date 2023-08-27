using VanyaTeach.Course.Data.Models;
using VanyaTeach.Course.Data.Models.Read;

namespace VanyaTeach.Course.Data.Repositories.Homeworks;

public interface IHomeworkSubmissionRepository
{
    IEnumerable<HomeworkSubmission> GetAllForUser(Guid homeworkId);
    IEnumerable<HomeworkSubmission> GetAllForLesson(Guid lessonId);
    IEnumerable<HomeworkSubmission> GetAllForMentor(Guid mentorId);
    HomeworkSubmission GetById(Guid id);
    void Add(HomeworkSubmissionDto homework);
    void Update(Guid id, HomeworkSubmissionDto homework);
    void Delete(Guid id); 
}