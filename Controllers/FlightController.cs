using Flight_Booking_System_AP.DBContext;
using Flight_Booking_System_AP.DTOs; // Your DTO namespace
using Flight_Booking_System_AP.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Flight_Booking_System_AP.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class FlightController : ControllerBase
    {
        private readonly FlightBookingContext _context;

        public FlightController(FlightBookingContext bookingContext)
        {
            _context = bookingContext;
        }

        // 🔐 Only users with role = Admin can call this
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddFlight([FromBody] FlightCreateDto flightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _context.Flights.AnyAsync(f => f.FlightNumber == flightDto.FlightNumber))
                return BadRequest("Flight number must be unique.");

            if (!await _context.Airports.AnyAsync(a => a.ID == flightDto.OriginAirportId))
                return BadRequest("Origin airport does not exist.");

            if (!await _context.Airports.AnyAsync(a => a.ID == flightDto.DestinationAirportId))
                return BadRequest("Destination airport does not exist.");

            if (flightDto.ArrivalTime <= flightDto.DepartureTime)
                return BadRequest("Arrival time must be after departure time.");

            var flight = new Flight
            {
                FlightNumber = flightDto.FlightNumber,
                OriginAirportId = flightDto.OriginAirportId,
                DestinationAirportId = flightDto.DestinationAirportId,
                DepartureTime = flightDto.DepartureTime,
                ArrivalTime = flightDto.ArrivalTime
            };

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddFlight), new { id = flight.Id }, flight);
        }
        // ✅ Anyone (even unauthenticated) can get all flights
        [AllowAnonymous]
        [HttpGet("all")]
       
            public IActionResult GetAllFlights()
            {
                // Only authenticated users can call this
                return Ok(/* flights */);
            }
        }
    }

