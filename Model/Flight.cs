using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using YourNamespace.Models;

namespace Flight_Booking_System_AP.Model
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public int OriginAirportId { get; set; }

        [Required]
        public int DestinationAirportId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        // Navigation Properties
        [ForeignKey("OriginAirportId")]
        public Airport OriginAirport { get; set; }

        [ForeignKey("DestinationAirportId")]
        public Airport DestinationAirport { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
