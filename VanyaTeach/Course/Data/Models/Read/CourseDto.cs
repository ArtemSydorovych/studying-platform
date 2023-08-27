namespace VanyaTeach.Course.Data.Models.Read;

public class CourseDto
{
    public Guid Id = Guid.NewGuid();
    public string? Name;
    public required List<Guid> ListLessonsIds;
}
