namespace VanyaTeach.Course.Data.Models.Read;

public class LessonModuleDto
{
    public required string Title { get; set; }
    public Guid CourseId { get; set; }
}