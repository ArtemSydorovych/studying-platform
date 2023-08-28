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
        // Configuring the User (base) entity
        modelBuilder.Entity<Models.User>()
            .ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<Student>("Student")
            .HasValue<Mentor>("Mentor");

        // Configuring the Student entity
        modelBuilder.Entity<Student>()
            .ToTable("Students")
            .HasKey(u => u.Id);
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Mentor)
            .WithMany(m => m.Students)
            .HasForeignKey(s => s.MentorId);

        // Configuring the Mentor entity
        modelBuilder.Entity<Mentor>()
            .ToTable("Mentors")
            .HasKey(m => m.Id);
        modelBuilder.Entity<Mentor>();

        base.OnModelCreating(modelBuilder);
    }
}