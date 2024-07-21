using Microsoft.EntityFrameworkCore;
using School_Table_1.Entities;

namespace School_Table_1.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) 
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
