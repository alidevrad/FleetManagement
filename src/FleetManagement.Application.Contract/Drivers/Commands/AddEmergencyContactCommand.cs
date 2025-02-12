using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record AddEmergencyContactCommand(long DriverId,
                                         string Name,
                                         string Relationship,
                                         string PhoneNumber) : ICommand;
