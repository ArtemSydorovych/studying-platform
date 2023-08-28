using Microsoft.EntityFrameworkCore;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Data.EntityFramework;

public class UserContext : DbContext
{
    public required DbSet<Student> Students { get; set; }
    public required DbSet<Mentor> Mentors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Filename=./mydatabase.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuring the UserDto entity
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasOne(s => s.Mentor)
                .WithMany(m => m.Students)
                .HasForeignKey(s => s.MentorId);
        });

        modelBuilder.Entity<Mentor>(entity =>
        {
            entity.HasKey(m => m.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}