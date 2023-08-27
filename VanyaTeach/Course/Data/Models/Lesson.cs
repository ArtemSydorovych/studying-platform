namespace VanyaTeach.Course.Data.Models;

public class Lesson
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public Guid ModuleId { get; set; }
    public required LessonsModule LessonsModule{ get; set; }
    public required HomeworkDescription HomeworkDescription { get; set; }
    public required List<HomeworkSubmission> UserSubmissions { get; set; }
}
