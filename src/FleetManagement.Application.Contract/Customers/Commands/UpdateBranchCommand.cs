using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Common.BuildingBlocks;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record UpdateBranchCommand(
    long CustomerId,
    long BranchId,
    string Name,
    double Latitude,
    double Longitude,
    string Address,
    string AgentFullName,
    PhoneNumber AgentPhoneNumber
) : ICommand;
