using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CargoTrackingg.Migrations
{
    /// <inheritdoc />
    public partial class SeedRolesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "customer-id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "musteri-role-id", null, "Müşteri", "MÜŞTERİ" },
                    { "personel-role-id", null, "Personel", "PERSONEL" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "musteri-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "personel-role-id");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin-id", 0, "6a575e1c-bfde-4824-8b74-a09a159836b7", new DateTime(2025, 5, 7, 15, 16, 33, 269, DateTimeKind.Utc).AddTicks(4873), "admin@cargo.com", true, "Admin Personel", false, null, "ADMIN@CARGO.COM", "ADMIN", "AQAAAAIAAYagAAAAEMqsb9SqACfbmeI0qHxpIOI9ZD7vQkoh4vgq3NKAlWjkpjhOjBfhOUOHVs9Wo1zRKQ==", null, false, "Personel", "235c8e97-289b-48c8-8000-8b3b392d464e", false, "admin" },
                    { "customer-id", 0, "a0a5c637-3638-4263-ab53-537d7b18ed16", new DateTime(2025, 5, 7, 15, 16, 33, 327, DateTimeKind.Utc).AddTicks(2194), "customer@cargo.com", true, "Test Müşteri", false, null, "CUSTOMER@CARGO.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEOyIQysjcUTfIolCejvt083w48IVOZbUrPk2NbmO0O/z0X/eHxLjolCj7UFRwKiqyQ==", null, false, "Müşteri", "45d91527-eae1-4e9c-80b7-3ee4233a11fd", false, "customer" }
                });
        }
    }
}
