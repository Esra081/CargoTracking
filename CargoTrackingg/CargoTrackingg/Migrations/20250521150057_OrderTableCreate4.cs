using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableCreate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Shipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_BranchId",
                table: "Shipments",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Branches_BranchId",
                table: "Shipments",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Branches_BranchId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_BranchId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Shipments");
        }
    }
}
