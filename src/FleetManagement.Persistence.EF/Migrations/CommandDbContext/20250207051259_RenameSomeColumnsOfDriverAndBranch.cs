using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    /// <inheritdoc />
    public partial class RenameSomeColumnsOfDriverAndBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Drivers",
                newName: "DriverPhoneNumberTitle");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Drivers",
                newName: "DriverPhoneNumberCountryCode");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Drivers",
                newName: "DriverPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Branches",
                newName: "AgentPhoneNumberTitle");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Branches",
                newName: "AgentPhoneNumberCountryCode");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Branches",
                newName: "AgentPhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverPhoneNumberTitle",
                schema: "Fleet",
                table: "Drivers",
                newName: "PhoneNumberTitle");

            migrationBuilder.RenameColumn(
                name: "DriverPhoneNumberCountryCode",
                schema: "Fleet",
                table: "Drivers",
                newName: "PhoneNumberCountryCode");

            migrationBuilder.RenameColumn(
                name: "DriverPhoneNumber",
                schema: "Fleet",
                table: "Drivers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AgentPhoneNumberTitle",
                schema: "Fleet",
                table: "Branches",
                newName: "PhoneNumberTitle");

            migrationBuilder.RenameColumn(
                name: "AgentPhoneNumberCountryCode",
                schema: "Fleet",
                table: "Branches",
                newName: "PhoneNumberCountryCode");

            migrationBuilder.RenameColumn(
                name: "AgentPhoneNumber",
                schema: "Fleet",
                table: "Branches",
                newName: "PhoneNumber");
        }
    }
}
