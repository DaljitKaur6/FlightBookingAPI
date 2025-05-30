using Flight_Booking_System_AP.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using YourNamespace.Models;

namespace Flight_Booking_System_AP.DBContext
{
    public class FlightBookingContext : DbContext
    {
        public FlightBookingContext(DbContextOptions<FlightBookingContext> options)
        : base(options) { }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                .HasMany(a => a.DepartingFlights)
                .WithOne(f => f.OriginAirport)
                .HasForeignKey(f => f.OriginAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Airport>()
                .HasMany(a => a.ArrivingFlights)
                .WithOne(f => f.DestinationAirport)
                .HasForeignKey(f => f.DestinationAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasIndex(f => f.FlightNumber)
                .IsUnique(); // Unique flight number constraint
        }
        public static class DataSeeder
        {
            public static void Seed(FlightBookingContext context)
            {
                if (!context.Airports.Any())
                {
                    context.Airports.AddRange(
                        new Airport { AirportCode = "YYZ", Name = "Toronto Pearson" },
                        new Airport { AirportCode = "YVR", Name = "Vancouver International" }
                    );
                    context.SaveChanges();
                }

                if (!context.Flights.Any())
                {
                    var yyz = context.Airports.Single(a => a.AirportCode == "YYZ");
                    var yvr = context.Airports.Single(a => a.AirportCode == "YVR");

                    context.Flights.Add(new Flight
                    {
                        FlightNumber = "AC100",
                        OriginAirportId = yyz.ID,
                        DestinationAirportId = yvr.ID,
                        DepartureTime = DateTime.UtcNow.AddDays(5),
                        ArrivalTime = DateTime.UtcNow.AddDays(5).AddHours(5)
                    }); ; 
                    context.SaveChanges();
                }
            }
        }

    }

}
