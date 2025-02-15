using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record ReleaseDriverFromReservationCommand(long Id, long ReservationId) : ICommand;
