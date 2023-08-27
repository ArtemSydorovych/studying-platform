using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.User.Data.Models;

public class UserDto
{
    public Guid Id = Guid.NewGuid();
    public required string Name;
    public required Guid MentorId;
    public List<Purchase>? Purchases;
    public List<HomeworkSubmission>? Homeworks;
}

public class Purchase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CourseId;
    public required Course.Data.Models.Course Course;
    public DateTime PurchaseDate;
    public DateTime ExpiryDate;
    public int FreezeDuration;
}
