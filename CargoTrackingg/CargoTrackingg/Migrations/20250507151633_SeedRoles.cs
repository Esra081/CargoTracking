using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a575e1c-bfde-4824-8b74-a09a159836b7", new DateTime(2025, 5, 7, 15, 16, 33, 269, DateTimeKind.Utc).AddTicks(4873), "AQAAAAIAAYagAAAAEMqsb9SqACfbmeI0qHxpIOI9ZD7vQkoh4vgq3NKAlWjkpjhOjBfhOUOHVs9Wo1zRKQ==", "235c8e97-289b-48c8-8000-8b3b392d464e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer-id",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a5c637-3638-4263-ab53-537d7b18ed16", new DateTime(2025, 5, 7, 15, 16, 33, 327, DateTimeKind.Utc).AddTicks(2194), "AQAAAAIAAYagAAAAEOyIQysjcUTfIolCejvt083w48IVOZbUrPk2NbmO0O/z0X/eHxLjolCj7UFRwKiqyQ==", "45d91527-eae1-4e9c-80b7-3ee4233a11fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd31682e-c4aa-46e3-a28e-02a56a934b5f", new DateTime(2025, 5, 7, 15, 14, 12, 382, DateTimeKind.Utc).AddTicks(9931), "AQAAAAIAAYagAAAAECbDNALg5GQ4YD6lHfwT+HRk6rAgX5O+/qz/SrDzH3cSK11nJjDTf4D3un5pf3nfQA==", "ec83c9e4-577a-4527-8dfd-97fa8775c7d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer-id",
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5446a7fa-2850-4cfe-8dbb-b57b846e40bc", new DateTime(2025, 5, 7, 15, 14, 12, 455, DateTimeKind.Utc).AddTicks(7482), "AQAAAAIAAYagAAAAEECrIFrNWXzfCIiHhkCBIbV3nvXyOmA0kUMXG0+JHLBELzLiiDix6T1qTg17xdsU6Q==", "53d5841a-c803-48ca-a853-f692e54f6f38" });
        }
    }
}
