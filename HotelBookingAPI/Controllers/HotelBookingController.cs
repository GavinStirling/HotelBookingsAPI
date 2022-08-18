using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly HotelBookingContext _context;

        public HotelBookingController (HotelBookingContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult createEdit (HotelBooking booking)
        {
            if (booking.id == 0)
            {
                _context.Add(booking);
            } else
            {
                var existingBooking = _context.bookings.Find(booking.id);
                if (existingBooking == null)
                {
                    return new JsonResult(NotFound());
                }
                existingBooking = booking;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        // Get
        [HttpGet]
        public JsonResult get(int id)
        {
            var result = _context.bookings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }

        // Get all
        [HttpGet]
        public JsonResult getAll()
        {
            var result = _context.bookings.ToList();
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult delete(int id)
        {
            var result = _context.bookings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.bookings.Remove(result);
            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }

    }
}
