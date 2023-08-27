using Microsoft.EntityFrameworkCore;

namespace VanyaTeach.User.Data.EntityFramework;

public class UserContext : DbContext
{
    public required DbSet<Models.User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Filename=./mydatabase.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuring the UserDto entity
        modelBuilder.Entity<Models.User>(entity =>
        {
            entity.HasKey(u => u.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}