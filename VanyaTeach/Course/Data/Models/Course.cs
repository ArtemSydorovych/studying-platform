namespace VanyaTeach.Course.Data.Models;

public class Course
{
    public Guid Id = Guid.NewGuid();
    public string? Name;
    public required List<LessonsModule> Modules;
}