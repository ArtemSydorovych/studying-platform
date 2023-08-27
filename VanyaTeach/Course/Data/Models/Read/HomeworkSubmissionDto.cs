namespace VanyaTeach.Course.Data.Models.Read;

public class HomeworkSubmissionDto
{
    public Guid UserId { get; set; } 
    public Guid LessonId { get; set; }
    public required string FileUrl { get; set; }
}