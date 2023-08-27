namespace VanyaTeach.Course.Data.Models;

public class HomeworkSubmission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; } 
    public required User.Data.Models.User User { get; set; } 
    public Guid LessonId { get; set; }
    public required Lesson Lesson { get; set; }
    public required string FileUrl { get; set; }
}