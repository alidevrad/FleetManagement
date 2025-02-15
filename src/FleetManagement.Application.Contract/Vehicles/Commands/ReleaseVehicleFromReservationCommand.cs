using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record ReleaseVehicleFromReservationCommand(long Id, long ReservationId) : ICommand;