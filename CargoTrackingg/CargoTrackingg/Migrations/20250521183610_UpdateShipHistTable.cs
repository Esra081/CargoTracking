using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShipHistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ShipmentStatusHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentStatusHistories_AppUserId",
                table: "ShipmentStatusHistories",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentStatusHistories_AspNetUsers_AppUserId",
                table: "ShipmentStatusHistories",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentStatusHistories_AspNetUsers_AppUserId",
                table: "ShipmentStatusHistories");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentStatusHistories_AppUserId",
                table: "ShipmentStatusHistories");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ShipmentStatusHistories");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_AppUserId",
                table: "Shipments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
