using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Minds.DataEF.Models;

namespace Minds.DataEF
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet properties
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        // Configure MySQL as the database provider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;port=3306;database=mind;user=root;password=marcelo;";

            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
        }

        // Model configuration and data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasKey(d => d.DepartmentId);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Department)
                        .WithMany(d => d.Employees)
                        .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, Name = "Human Resources" },
                new Department { DepartmentId = 2, Name = "IT" },
                new Department { DepartmentId = 3, Name = "Finance" }
            );

        }
    }
}
