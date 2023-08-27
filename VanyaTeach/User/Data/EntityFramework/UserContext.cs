using Microsoft.EntityFrameworkCore;
using VanyaTeach.User.Data.Models;

namespace VanyaTeach.User.Data.EntityFramework;

public class UserContext : DbContext
{
    public required DbSet<UserDto> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Filename=./mydatabase.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuring the UserDto entity
        modelBuilder.Entity<UserDto>(entity =>
        {
            entity.HasKey(u => u.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}