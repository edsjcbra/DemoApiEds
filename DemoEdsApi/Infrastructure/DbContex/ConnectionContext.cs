using DemoEdsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEdsApi.Infrastructure.DbContex
{
    public class ConnectionContext : DbContext
    {
        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Employee>()
                .Property(p => p.name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            modelBuilder.Entity<Employee>()
                .Property(p => p.photo)
                .IsRequired()
                .HasColumnType("varchar(250)");

            modelBuilder.Entity<Employee>()
                .ToTable("Employees");

            base.OnModelCreating(modelBuilder);
        }
    }
}
