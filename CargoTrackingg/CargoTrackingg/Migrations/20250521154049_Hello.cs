using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class Hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_AppUserId",
                table: "Shipments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_AppUserId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Shipments");
        }
    }
}
