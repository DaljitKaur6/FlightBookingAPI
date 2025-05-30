using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_System_AP.DTO
{
    public class AuthRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
