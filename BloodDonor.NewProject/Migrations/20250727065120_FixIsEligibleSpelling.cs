using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.NewProject.Migrations
{
    /// <inheritdoc />
    public partial class FixIsEligibleSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEliglible",
                table: "BloodDonors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsEliglible",
                value: false);

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsEliglible",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEliglible",
                table: "BloodDonors");
        }
    }
}
