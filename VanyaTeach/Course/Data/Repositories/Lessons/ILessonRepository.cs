using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.Course.Data.Repositories.Lessons;

public interface ILessonRepository
{
    void AddLesson(Lesson lesson);
    IEnumerable<Lesson> GetAllLessons();
    Lesson GetLessonById(Guid id);
    void UpdateLesson(Lesson lesson);
    void DeleteLesson(Guid id);
        
    void AddHomeworkDescriptionToLesson(Guid lessonId, HomeworkDescription homeworkDescription);
    void UpdateHomeworkDescriptionInLesson(Guid lessonId, HomeworkDescription updatedHomeworkDescription);
    void DeleteHomeworkDescriptionFromLesson(Guid lessonId);
        
    void UploadHomeworkSubmissionToLesson(Guid lessonId, HomeworkSubmission homeworkSubmission);
    void UpdateHomeworkSubmissionInLesson(Guid lessonId, HomeworkSubmission updatedHomeworkSubmission);
    void DeleteHomeworkSubmissionFromLesson(Guid lessonId, Guid homeworkSubmissionId);
}