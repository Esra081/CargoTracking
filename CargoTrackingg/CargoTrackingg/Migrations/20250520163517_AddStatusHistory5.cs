using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusHistory5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentStatusHistories_Branches_BranchId",
                table: "ShipmentStatusHistories");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "ShipmentStatusHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentStatusHistories_Branches_BranchId",
                table: "ShipmentStatusHistories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentStatusHistories_Branches_BranchId",
                table: "ShipmentStatusHistories");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "ShipmentStatusHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentStatusHistories_Branches_BranchId",
                table: "ShipmentStatusHistories",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
