namespace VanyaTeach.Course.Data.Models;

public class LessonsModule
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Title { get; set; }
    public Guid CourseId { get; set; }
    public required Course Course { get; set; }
    public required List<Lesson> Lessons { get; set; }
}