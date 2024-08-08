using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.StudentManagementAPI.Backend.Models;

namespace StudentManagementAPI.StudentManagementAPI.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }

}

