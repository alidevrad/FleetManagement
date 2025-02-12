using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record CreateVehicleCommand(
    long VehicleTypeId,
    string Manufacturer,
    string LicensePlateNumber,
    int ModelYear,
    string Color
) : ICommand<long>;