using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Common.BuildingBlocks;

namespace FleetManagement.Application.Contract.Warehouses.Commands;

public record UpdateWarehouseCommand(
    long Id,
    string Name,
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country,
    PhoneNumber PhoneNumber,
    string Email,
    double Latitude,
    double Longitude
) : ICommand;
