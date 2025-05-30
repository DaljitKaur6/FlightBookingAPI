using Flight_Booking_System_AP.DBContext;
using Flight_Booking_System_AP.Model;

namespace Flight_Booking_System_AP.Seed
{
    public class Seed
    {
        public static async Task SeedAdminAsync(FlightBookingContext context, IConfiguration configuration)
        {
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                CreatePasswordHash("Admin@123", out byte[] passwordHash, out byte[] passwordSalt);

                var adminUser = new User
                {
                    Email = "admin@flightbookingsystem.com",
                    Username = "admin",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = "Admin"
                };

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
