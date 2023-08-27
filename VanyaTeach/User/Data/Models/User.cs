using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.User.Data.Models;

public class User
{
    public Guid Id = Guid.NewGuid();
    public required string Name;
    public Guid MentorId;
    public List<Purchase>? Purchases = new List<Purchase>();
    public List<HomeworkSubmission>? Homeworks = new List<HomeworkSubmission>();
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
