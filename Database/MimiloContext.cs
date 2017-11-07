using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mimilo.Models;

namespace Mimilo.Database
{
    public class MimiloContext : IdentityDbContext<MimiloUser, MimiloRole, string>
    {
        public MimiloContext(DbContextOptions<MimiloContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}