using Flight_Booking_System_AP.DBContext;
using Flight_Booking_System_AP.Model;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Booking_System_AP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController :ControllerBase
    {
        private readonly FlightBookingContext _context;
        public AirportController(FlightBookingContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddAirport([FromBody] Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { error = "Invalid airport data", details = ModelState });
            }


            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddAirport), new { id = airport.ID }, airport);
        }
    }
}
