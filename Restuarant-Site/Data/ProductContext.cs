using Microsoft.EntityFrameworkCore;
using Restuarant_Site.Models;

namespace Restuarant_Site.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
