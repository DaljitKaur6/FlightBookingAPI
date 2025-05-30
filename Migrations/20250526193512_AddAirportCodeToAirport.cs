using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flight_Booking_System_AP.Migrations
{
    /// <inheritdoc />
    public partial class AddAirportCodeToAirport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirportCode",
                table: "Airports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirportCode",
                table: "Airports");
        }
    }
}
