using Microsoft.EntityFrameworkCore;
using ProjectMenuAPI.Entities;

namespace ProjectMenuAPI.Data
{
    public class MSDbContext : DbContext
    {




        public MSDbContext()
        {
        }
        public MSDbContext(DbContextOptions<MSDbContext> options)
         : base(options)
        {

        }

        public virtual DbSet<MenuItem> MenuItems { get; set; }
       

    }
}

