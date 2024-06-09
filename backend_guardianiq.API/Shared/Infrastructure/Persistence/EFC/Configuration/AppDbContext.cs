using backend_guardianiq.API.ActiveService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_guardianiq.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public DbSet<Service> Service { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Service>().ToTable("Service");
        modelBuilder.Entity<Service>().HasKey(p=>p.Id);
    }
}