using Microsoft.EntityFrameworkCore;
using miniproject.Models.Entity;

namespace miniproject.data
{
    public class Applicationdbcontext : DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options):base (options)
        {
            
        }
        public DbSet<Student>Students{ get; set; }

    }
}
