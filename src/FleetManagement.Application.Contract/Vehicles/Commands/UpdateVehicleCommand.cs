using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record UpdateVehicleCommand(
        long Id,
        long VehicleTypeID,
        string Manufacturer,
        string LicensePlateNumber,
        int ModelYear,
        string Color,
        string LicensePlateImageUrl
    ) : ICommand;
