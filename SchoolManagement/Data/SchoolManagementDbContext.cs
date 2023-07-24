using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class SchoolManagementDbContext:DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext>options):base(options) { }
        
        public DbSet <Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
