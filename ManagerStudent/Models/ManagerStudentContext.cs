using Microsoft.EntityFrameworkCore;

namespace ManagerStudent.Models
{
    public class ManagerStudentContext : DbContext
    {
        public ManagerStudentContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Student>().HasData(
                new Student() { Id = "1", UserName = "chunguyenchuong2014bg@gmail.com", Password = "123", isAdmin = true }
            );
        }
    }
}