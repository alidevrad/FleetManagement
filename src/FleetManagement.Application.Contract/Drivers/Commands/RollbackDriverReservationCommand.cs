using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record RollbackDriverReservationCommand(long DriverId, long ReservationId) : ICommand;
