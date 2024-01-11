using Microsoft.EntityFrameworkCore;
using WebApplication1.Model.Domain;

namespace WebApplication1.Model
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
