using Microsoft.EntityFrameworkCore;
using Mimilo.Models;

namespace Mimilo.Database
{
    public class MimiloContext : DbContext
    {
        public MimiloContext(DbContextOptions<MimiloContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}