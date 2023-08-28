using VanyaTeach.User.Data.Models;

namespace VanyaTeach.Course.Data.Models;

public class HomeworkSubmission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid StudentId { get; set; } 
    public required Student Student { get; set; } 
    public Guid LessonId { get; set; }
    public required Lesson Lesson { get; set; }
    public required string FileUrl { get; set; }
}