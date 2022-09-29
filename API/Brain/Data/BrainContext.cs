using Brain.Models;
using Microsoft.EntityFrameworkCore;


namespace Brain.Data
{
    public class BrainContext : DbContext
    {
        public BrainContext(DbContextOptions<BrainContext> opt) : base(opt)
        {
        }

        public DbSet<Command> Command { get; set; }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}