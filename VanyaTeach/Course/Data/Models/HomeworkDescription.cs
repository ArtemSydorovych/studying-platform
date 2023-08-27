namespace VanyaTeach.Course.Data.Models;

public class HomeworkDescription
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Description { get; set; }
    public required string FileUrl { get; set; }

    public Guid LessonId { get; set; }
    public required Lesson Lesson { get; set; }
}