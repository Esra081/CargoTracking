using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescForShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackageDescription",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageDescription",
                table: "Shipments");
        }
    }
}
