using Flight_Booking_System_AP.DBContext;
using Flight_Booking_System_AP.DTOs; // Your DTO namespace
using Flight_Booking_System_AP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flight_Booking_System_AP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly FlightBookingContext _context;

        public BookingController(FlightBookingContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if flight exists
            bool flightExists = await _context.Flights.AnyAsync(f => f.Id == bookingDto.FlightId);
            if (!flightExists)
            {
                return BadRequest("Flight does not exist.");
            }

            // Map DTO to entity
            var booking = new YourNamespace.Models.Booking
            {
                FlightId = bookingDto.FlightId,
                PassengerName = bookingDto.PassengerName,
                PassengerEmail = bookingDto.PassengerEmail, // <-- This is likely missing!
                BookingDate = bookingDto.BookingDate
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateBooking), new { id = booking.Id }, booking);
        }
    }
}
