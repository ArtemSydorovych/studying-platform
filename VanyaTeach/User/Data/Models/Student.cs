using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.User.Data.Models;

public class Student : User
{
    public Guid MentorId;
    public Mentor Mentor = null!;
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
