using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    /// <inheritdoc />
    public partial class AddVehicleTypeAndRefactorVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageFuelConsumption",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LoadCapacity",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.AddColumn<long>(
                name: "VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                schema: "Fleet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    MaxWeightCapacity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MaxVolumeCapacity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FuelType = table.Column<byte>(type: "tinyint", nullable: false),
                    AverageFuelConsumption = table.Column<double>(type: "float(10)", precision: 10, scale: 2, nullable: false),
                    RequiredLicenseType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: false),
                    IsHazardousMaterialApproved = table.Column<bool>(type: "bit", nullable: false),
                    MaxSpeedLimit = table.Column<int>(type: "int", nullable: false),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalSchema: "Fleet",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "Fleet");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                schema: "Fleet",
                table: "Vehicles");

            migrationBuilder.AddColumn<double>(
                name: "AverageFuelConsumption",
                schema: "Fleet",
                table: "Vehicles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "LoadCapacity",
                schema: "Fleet",
                table: "Vehicles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "VehicleType",
                schema: "Fleet",
                table: "Vehicles",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
