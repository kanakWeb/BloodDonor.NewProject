using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.NewProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedDataForBloodDonorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "LastDonationDate", "Weight" },
                values: new object[] { "Nepal", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65f });

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "LastDonationDate", "Weight" },
                values: new object[] { "Pakistan", new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "LastDonationDate", "Weight" },
                values: new object[] { null, null, 0f });

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "LastDonationDate", "Weight" },
                values: new object[] { null, null, 0f });
        }
    }
}
