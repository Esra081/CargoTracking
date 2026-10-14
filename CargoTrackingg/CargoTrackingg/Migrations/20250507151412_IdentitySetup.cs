using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class IdentitySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "AspNetUsers",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-id", 0, "bd31682e-c4aa-46e3-a28e-02a56a934b5f", new DateTime(2025, 5, 7, 15, 14, 12, 382, DateTimeKind.Utc).AddTicks(9931), "admin@cargo.com", true, "Admin Personel", false, null, "ADMIN@CARGO.COM", "ADMIN", "AQAAAAIAAYagAAAAECbDNALg5GQ4YD6lHfwT+HRk6rAgX5O+/qz/SrDzH3cSK11nJjDTf4D3un5pf3nfQA==", null, false, "Personel", "ec83c9e4-577a-4527-8dfd-97fa8775c7d4", false, "admin" },
                    { "customer-id", 0, "5446a7fa-2850-4cfe-8dbb-b57b846e40bc", new DateTime(2025, 5, 7, 15, 14, 12, 455, DateTimeKind.Utc).AddTicks(7482), "customer@cargo.com", true, "Test Müşteri", false, null, "CUSTOMER@CARGO.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEECrIFrNWXzfCIiHhkCBIbV3nvXyOmA0kUMXG0+JHLBELzLiiDix6T1qTg17xdsU6Q==", null, false, "Müşteri", "53d5841a-c803-48ca-a853-f692e54f6f38", false, "customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer-id");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "AspNetUsers",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
