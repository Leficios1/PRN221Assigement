using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class Db2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "BookingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_ServiceId",
                table: "BookingDetails",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Service_ServiceId",
                table: "BookingDetails",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Service_ServiceId",
                table: "BookingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_ServiceId",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "BookingDetails");
        }
    }
}
