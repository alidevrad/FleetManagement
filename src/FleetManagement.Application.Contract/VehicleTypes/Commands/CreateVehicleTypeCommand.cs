using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Models.VehicleTypes.Enums;

namespace FleetManagement.Application.Contract.VehicleTypes.Commands;

public record CreateVehicleTypeCommand(
    string Name,
    VehicleCategory Category,
    decimal MaxWeightCapacity,
    decimal MaxVolumeCapacity,
    FuelType FuelType,
    double AverageFuelConsumption,
    string RequiredLicenseType,
    bool IsRefrigerated,
    bool IsHazardousMaterialApproved,
    int MaxSpeedLimit,
    int NumberOfWheels
) : ICommand<long>;
