using Microsoft.EntityFrameworkCore;
using Restuarant_Site.Models;

namespace Restuarant_Site.Data
{
    public class CouponContext : DbContext
    {
        public CouponContext(DbContextOptions<CouponContext> options) : base(options)
        {
        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
