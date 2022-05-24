using Microsoft.EntityFrameworkCore;
using Restuarant_Site.Models;

namespace Restuarant_Site.Data
{
    public class IngredientContext : DbContext
    {
        public IngredientContext(DbContextOptions<IngredientContext> options) : base(options)
        {
        }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
