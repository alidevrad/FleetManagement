using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record RollbackVehicleReservationCommand(long VehicleId, long ReservationId) : ICommand;
