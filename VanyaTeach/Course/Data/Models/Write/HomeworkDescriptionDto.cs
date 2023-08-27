namespace VanyaTeach.Course.Data.Models.Read;

public class HomeworkDescriptionDto
{
    public required string Description { get; set; }
    public Guid LessonId { get; set; }
}