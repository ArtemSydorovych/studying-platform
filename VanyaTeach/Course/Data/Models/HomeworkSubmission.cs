using VanyaTeach.User.Data.Models;

namespace VanyaTeach.Course.Data.Models;

public class HomeworkSubmission
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }  // This refers back to your UserDto or UserEntity
    public required UserDto User { get; set; }  // Change this to your actual User entity name if different
    public Guid LessonId { get; set; }
    public required Lesson Lesson { get; set; }
    public required string FileUrl { get; set; } // Assuming you'll store a URL to the uploaded file. You could store the actual file data if preferred.
}