using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodDonor.NewProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForBloodDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BloodDonors",
                columns: new[] { "Id", "Address", "BloodGroup", "ContactNumber", "DateOfBirth", "Email", "FullName", "LastDonationDate", "ProfilePicture", "Weight" },
                values: new object[,]
                {
                    { 1, null, 0, "1234567890", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John@gmail.com", "John Doe", null, null, 0f },
                    { 2, null, 3, "0987654321", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane@gmail.com", "Jane Smith", null, null, 0f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
