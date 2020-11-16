using LXP.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LXP.api.DbContexts
{
    public class RoutineDbContext : DbContext
    {
        public RoutineDbContext(DbContextOptions<RoutineDbContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> Tasks { get; set; }

        //define restriction when create model related to entity, the relationship between 2 entities is many to many without foreignkey.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>()
                .Property(x => x.TaskList).HasMaxLength(500);
            modelBuilder.Entity<EmployeeTask>()
                .Property(x => x.TaskName).IsRequired().HasMaxLength(50);

            // build relationship and restrict
            //modelBuilder.Entity<EmployeeTask>()
            //    .HasOne(navigationExpression: x => x.Employee)
            //    .WithMany(navigationExpression: x => x.Tasks)
            //    .HasForeignKey(x => x.TaskName)
            //    .OnDelete(DeleteBehavior.Restrict);
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.Parse("A3A461EA-E692-6F54-2F3E-F076A08DDA14"),
                    FirstName = "XiaoPeng",
                    LastName = "Luo",
                    HiredDate = DateTime.Parse("2021-1-1"),
                    TaskList = "Fix bugs, CRUD a entity, Design module"
                },
                new Employee
                {
                    Id = Guid.Parse("16781DAE-0522-A9D3-AC94-66D6B76AA772"),
                    FirstName = "GuanXi",
                    LastName = "Chen",
                    HiredDate = DateTime.Now,
                    TaskList = "Design module, Take photo"
                }
                );

            modelBuilder.Entity<EmployeeTask>().HasData(
                new EmployeeTask
                {
                    TaskName = "Fix bugs",
                    StartTime = DateTimeOffset.Now,
                    DeadLine = DateTimeOffset.Parse("2021-1-1")
                },
                new EmployeeTask
                {
                    TaskName = "CRUS a entity",
                    StartTime = DateTimeOffset.Now,
                    DeadLine = DateTimeOffset.Parse("2021-1-1")
                },
                new EmployeeTask
                {
                    TaskName = "Design module",
                    StartTime = DateTimeOffset.Now,
                    DeadLine = DateTimeOffset.Parse("2021-1-1")
                },
                new EmployeeTask
                {
                    TaskName = "Take photo",
                    StartTime = DateTimeOffset.Parse("2008-1-1"),
                    DeadLine = DateTimeOffset.Parse("2028-1-1")
                }
                );
        }
    }
}
