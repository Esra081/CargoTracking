using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeRelationToShipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
