using Microsoft.EntityFrameworkCore;
using Restuarant_Site.Models;

namespace Restuarant_Site.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
