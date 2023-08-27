using Microsoft.EntityFrameworkCore;
using VanyaTeach.Course.Data.Models;

namespace VanyaTeach.Course.Data.EntityFramework;

public class CourseContext : DbContext
{
    public required DbSet<Models.Course> Courses { get; set; }
    public required DbSet<LessonsModule> Modules { get; set; }
    public required DbSet<Lesson> Lessons { get; set; }
    public required DbSet<HomeworkDescription> HomeworkDescriptions { get; set; }
    public required DbSet<HomeworkSubmission> UserHomeworkSubmissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Filename=./mydatabase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Course configuration
        modelBuilder.Entity<Models.Course>(entity =>
        {
            entity.HasKey(c => c.Id);
        });

        modelBuilder.Entity<LessonsModule>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId);
        });

        // Lesson configuration
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.HasOne(l => l.LessonsModule)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.ModuleId);
            entity.HasOne(l => l.HomeworkDescription)
                .WithOne(h => h.Lesson)
                .HasForeignKey<HomeworkDescription>(h => h.LessonId);
            entity.HasMany(l => l.UserSubmissions)
                .WithOne(u => u.Lesson)
                .HasForeignKey(u => u.LessonId);
        });

        // UserHomeworkSubmission configuration
        modelBuilder.Entity<HomeworkSubmission>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasOne(u => u.User)
                .WithMany(u => u.Homeworks)
                .HasForeignKey(u => u.UserId);
        });

    }
}