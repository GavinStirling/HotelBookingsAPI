using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Data
{
    public class HotelBookingContext : DbContext
    {
        public DbSet<HotelBooking> bookings { get; set; }

        public HotelBookingContext(DbContextOptions<HotelBookingContext> options) : base(options)
        {

        }
    }
}
