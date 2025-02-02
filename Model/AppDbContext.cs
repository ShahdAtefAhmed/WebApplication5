using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ClassRoom> Classrooms { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Courses> Courses { get; set; }


    }
}
