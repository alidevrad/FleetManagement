using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record AddTrainingQualificationCommand(long DriverId,
                                              string QualificationName,
                                              DateTime? ObtainedDate,
                                              DateTime? ExpirationDate) : ICommand;