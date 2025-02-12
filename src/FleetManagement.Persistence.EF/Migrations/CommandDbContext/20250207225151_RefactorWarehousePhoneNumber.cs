using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    /// <inheritdoc />
    public partial class RefactorWarehousePhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Warehouses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Warehouses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberCountryCode",
                schema: "Fleet",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "PhoneNumberTitle",
                schema: "Fleet",
                table: "Warehouses");
        }
    }
}
