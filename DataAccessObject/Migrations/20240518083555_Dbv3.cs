using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessObject.Migrations
{
    /// <inheritdoc />
    public partial class Dbv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_User_UserId1",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_UserId1",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Pet");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "PetRecord",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PetRecord",
                newName: "RecordId");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Pet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_UserId1",
                table: "Pet",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_User_UserId1",
                table: "Pet",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
