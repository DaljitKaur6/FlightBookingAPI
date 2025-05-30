using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_System_AP.Model
{
    public class Airport
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(3)]
        public string Code { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string AirportCode { get; set; }

        // Navigation Properties
        public ICollection<Flight> DepartingFlights { get; set; } = new List<Flight>();
        public ICollection<Flight> ArrivingFlights { get; set; } = new List<Flight>();
    }
}

