using Flight_Booking_System_AP.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_System_AP.DTOs
{
    public class BookingCreateDto
    {
        public int Id { get; set; }

        public int FlightId { get; set; }

        public string PassengerName { get; set; }

        [Required]
        public string PassengerEmail { get; set; }  // ✅ must match DB column

        public DateTime BookingDate { get; set; }

       
    }
}
