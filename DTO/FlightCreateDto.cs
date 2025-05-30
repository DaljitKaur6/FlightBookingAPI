using System;
using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_System_AP.DTOs
{
    public class FlightCreateDto
    {
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
    }
}

