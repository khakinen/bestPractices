using System;
using BestPractices.EF.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BestPractices.EF.Data
{
    //public interface IAppDbContext
    //{
    //    DbSet<Student> Students { get; set; }
    //    DbSet<Teacher> Teachers { get; set; }
    //    Task<int> SaveChanges();
    //}

    public class AppDbContext : DbContext //, IAppDbContext
    {
        public AppDbContext()
            : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        //public async Task<int> SaveChanges()
        //{
        //    return await base.SaveChangesAsync();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>().HasData(
                new Student {Id = Guid.NewGuid(), Name = "Bob", StudentRank = 1},
                new Student {Id = Guid.NewGuid(), Name = "Alice", StudentRank = 2},
                new Student {Id = Guid.NewGuid(), Name = "Jack", StudentRank = 3});

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher {Id = Guid.NewGuid(), Name = "MrBob", TeacherRank = 1,},
                new Teacher {Id = Guid.NewGuid(), Name = "MrsAlice", TeacherRank = 2},
                new Teacher {Id = Guid.NewGuid(), Name = "MrJack", TeacherRank = 3});
        }
    }
}