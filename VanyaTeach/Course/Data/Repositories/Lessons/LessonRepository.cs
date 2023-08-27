using Microsoft.EntityFrameworkCore;
using VanyaTeach.Course.Data.EntityFramework;
using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.Course.Data.Repositories.Lessons;

public class LessonRepository(CourseContext context) : ILessonRepository
{
    public IEnumerable<Lesson> GetAllLessons() =>
        context.Lessons
            .Include(l => l.HomeworkDescription)
            .ToList();

    public Lesson GetLessonById(Guid id) =>
        context.Lessons
            .Include(l => l.HomeworkDescription)
            .FirstOrDefault(l => l.Id == id)!;

    public void AddLesson(Lesson lesson)
    {
        context.Lessons.Add(lesson);
        context.SaveChanges();
    }

    public void UpdateLesson(Lesson lesson)
    {
        var existingLesson = context.Lessons
            .Include(l => l.HomeworkDescription)
            .FirstOrDefault(l => l.Id == lesson.Id);

        if (existingLesson != null)
        {
            existingLesson.Title = lesson.Title;
            existingLesson.HomeworkDescription.Description = lesson.HomeworkDescription.Description;
            context.Entry(existingLesson).State = EntityState.Modified;
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lesson.Id} does not exist.");
        }
    }

    public void DeleteLesson(Guid id)
    {
        var lesson = context.Lessons.Find(id);

        if (lesson != null)
        {
            context.Lessons.Remove(lesson);
            context.SaveChanges();
        }
    }

    public void AddHomeworkDescriptionToLesson(Guid lessonId, HomeworkDescription homeworkDescription)
    {
        var lesson = context.Lessons.FirstOrDefault(l => l.Id == lessonId);

        if (lesson != null)
        {
            lesson.HomeworkDescription = homeworkDescription;
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lessonId} does not exist.");
        }
    }

    public void UploadHomeworkSubmissionToLesson(Guid lessonId, HomeworkSubmission homeworkSubmission)
    {
        var lesson = context.Lessons
            .Include(l => l.UserSubmissions)
            .FirstOrDefault(l => l.Id == lessonId);

        if (lesson != null)
        {
            context.UserHomeworkSubmissions.Add(homeworkSubmission);
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lessonId} does not exist.");
        }
    }

    public void UpdateHomeworkDescriptionInLesson(Guid lessonId, HomeworkDescription updatedHomeworkDescription)
    {
        var lesson = context.Lessons.Include(lesson => lesson.HomeworkDescription).FirstOrDefault(l => l.Id == lessonId);

        if (lesson != null)
        {
            lesson.HomeworkDescription.Description = updatedHomeworkDescription.Description;
            // Add any other fields of HomeworkDescription you wish to update here
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lessonId} does not exist or does not have an associated homework description.");
        }
    }

    public void DeleteHomeworkDescriptionFromLesson(Guid lessonId)
    {
        var lesson = context.Lessons.Include(lesson => lesson.HomeworkDescription).FirstOrDefault(l => l.Id == lessonId);

        if (lesson != null)
        {
            context.Remove(lesson.HomeworkDescription);
            lesson.HomeworkDescription = null!;
            context.SaveChanges();
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lessonId} does not exist or does not have an associated homework description.");
        }
    }

    public void UpdateHomeworkSubmissionInLesson(Guid lessonId, HomeworkSubmission updatedHomeworkSubmission)
    {
        throw new NotSupportedException("This method is not supported yet.");
    }

    public void DeleteHomeworkSubmissionFromLesson(Guid lessonId, Guid homeworkSubmissionId)
    {
        var lesson = context.Lessons
            .Include(l => l.UserSubmissions)
            .FirstOrDefault(l => l.Id == lessonId);

        if (lesson != null)
        {
            var submission = lesson.UserSubmissions.FirstOrDefault(h => h.Id == homeworkSubmissionId);

            if (submission != null)
            {
                context.Remove(submission);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Homework submission with ID {homeworkSubmissionId} does not exist for the lesson.");
            }
        }
        else
        {
            throw new ArgumentException($"Lesson with ID {lessonId} does not exist.");
        }
    }
}