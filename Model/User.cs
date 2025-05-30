using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_System_AP.Model
{
    public class User
    { 
      [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public byte[] PasswordHash { get; set; }

    [Required]
    public byte[] PasswordSalt { get; set; }

    public string Role { get; set; } = "Customer"; // or Admin
}
}
