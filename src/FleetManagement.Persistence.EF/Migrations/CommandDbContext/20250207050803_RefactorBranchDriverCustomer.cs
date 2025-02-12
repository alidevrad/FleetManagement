using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    /// <inheritdoc />
    public partial class RefactorBranchDriverCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NativeLanguage",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Fleet",
                table: "CustomerPhoneNumbers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "Fleet",
                table: "BranchPhoneNumbers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Fleet",
                table: "Branches",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgentFullName",
                schema: "Fleet",
                table: "Branches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Branches",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Branches",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Branches",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NativeLanguage",
                schema: "Fleet",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Fleet",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "Fleet",
                table: "BranchPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Fleet",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "AgentFullName",
                schema: "Fleet",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Branches");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "Fleet",
                table: "Drivers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
