using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagement.Persistence.EF.Migrations.CommandDbContext
{
    /// <inheritdoc />
    public partial class AddTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                schema: "Fleet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    TotalDelayTime = table.Column<double>(type: "float", nullable: false),
                    TotalTripDuration = table.Column<double>(type: "float", nullable: false),
                    TotalFuelConsumption = table.Column<double>(type: "float", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubTrips",
                schema: "Fleet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripId = table.Column<long>(type: "bigint", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DeliveryPoint_BranchId = table.Column<long>(type: "bigint", nullable: true),
                    DeliveryPoint_Order = table.Column<int>(type: "int", nullable: true),
                    DeliveryPoint_Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeliveryPoint_Latitude = table.Column<double>(type: "float", nullable: true),
                    DeliveryPoint_Longitude = table.Column<double>(type: "float", nullable: true),
                    RouteDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    FuelConsumption = table.Column<double>(type: "float", nullable: false),
                    DelayTimeValue = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalSchema: "Fleet",
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubTrips_TripId",
                schema: "Fleet",
                table: "SubTrips",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubTrips",
                schema: "Fleet");

            migrationBuilder.DropTable(
                name: "Trips",
                schema: "Fleet");
        }
    }
}
