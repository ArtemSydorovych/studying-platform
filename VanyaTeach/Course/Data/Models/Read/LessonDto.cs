namespace VanyaTeach.Course.Data.Models.Read;

public class LessonDto
{
    public required string Title { get; set; }
    public Guid ModuleId { get; set; }
    public required HomeworkDescriptionDto HomeworkDescription { get; set; }
}