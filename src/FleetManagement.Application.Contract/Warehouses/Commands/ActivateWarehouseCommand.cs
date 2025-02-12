using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Warehouses.Commands;

public record ActivateWarehouseCommand(long Id) : ICommand;