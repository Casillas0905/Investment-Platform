using InvestmentPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPlatform.DBAcces;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Data Source = ../InvestmentPlatform/Post.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
    }
}