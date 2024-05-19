using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class Dbv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Pet_PetId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Vet_VetId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_PetId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_VetId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "VetId",
                table: "Booking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VetId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PetId",
                table: "Booking",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_VetId",
                table: "Booking",
                column: "VetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Pet_PetId",
                table: "Booking",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Vet_VetId",
                table: "Booking",
                column: "VetId",
                principalTable: "Vet",
                principalColumn: "Id");
        }
    }
}
