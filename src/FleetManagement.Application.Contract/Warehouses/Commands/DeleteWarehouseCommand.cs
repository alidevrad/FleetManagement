using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Warehouses.Commands;

public record DeleteWarehouseCommand(long Id) : ICommand;