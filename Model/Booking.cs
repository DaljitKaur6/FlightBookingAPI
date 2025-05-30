using Flight_Booking_System_AP.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FlightId { get; set; }

        [Required]
        public string PassengerName { get; set; }

        [Required]
        [EmailAddress]
        public string PassengerEmail { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        // Navigation Property
        [ForeignKey("FlightId")]
        public Flight Flight { get; set; }
    }
}

