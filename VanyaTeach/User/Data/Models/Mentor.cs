namespace VanyaTeach.User.Data.Models;

public class Mentor : User
{
    public List<Student>? Students = new List<Student>();
}