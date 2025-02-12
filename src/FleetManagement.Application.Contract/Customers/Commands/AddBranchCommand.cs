using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Common.BuildingBlocks;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record AddBranchCommand(long CustomerId,
                               string Name,
                               double Latitude,
                               double Longitude,
                               List<PhoneNumber> PhoneNumbers,
                               string Address,
                               string AgentFullName,
                               PhoneNumber AgentPhoneNumber) : ICommand;
