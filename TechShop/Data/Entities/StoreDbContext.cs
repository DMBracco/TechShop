using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TechShop.Data.Entities
{
    public class StoreDbContext : IdentityDbContext<IdentityUser>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
