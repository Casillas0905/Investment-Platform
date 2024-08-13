using InvestmentPlatform.Domain;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPlatform.DBAcces;

public class Context : DbContext
{
    public DbSet<User> User { get; set; }
    
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
    }
}