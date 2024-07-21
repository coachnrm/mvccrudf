using Microsoft.EntityFrameworkCore;

namespace mvccrudf.Models
{
    public class mycontext:DbContext
    {
        public mycontext(DbContextOptions options):base(options)
        {

        }
        public DbSet<skill> skills {get; set;}
        public DbSet<student> students {get; set;}
    }
}