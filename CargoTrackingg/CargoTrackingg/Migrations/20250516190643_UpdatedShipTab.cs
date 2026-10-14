using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedShipTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Employees_EmployeeId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_EmployeeId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Shipments");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Shipments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Shipments",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Shipments");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Shipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_EmployeeId",
                table: "Shipments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Employees_EmployeeId",
                table: "Shipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
