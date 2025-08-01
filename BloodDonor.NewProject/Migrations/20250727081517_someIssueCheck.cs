using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodDonor.NewProject.Migrations
{
    /// <inheritdoc />
    public partial class someIssueCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEligible",
                table: "BloodDonors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEligible",
                table: "BloodDonors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsEligible",
                value: false);

            migrationBuilder.UpdateData(
                table: "BloodDonors",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsEligible",
                value: false);
        }
    }
}
