using FleetManagement.Application.Contract.Warehouses.Commands;
using FleetManagement.Domain.Models.Warehouses;
using FleetManagement.Domain.Models.Warehouses.Repositories;
using MediatR;

namespace FleetManagement.Application.Warehouses.Commands;

public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, long>
{
    private readonly IWarehouseCommandRepository _warehouseRepository;

    public CreateWarehouseCommandHandler(IWarehouseCommandRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public async Task<long> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var businessId = Guid.NewGuid();

        var warehouse = new Warehouse(
            request.Name, request.Street, request.City, request.State,
            request.PostalCode, request.Country, request.PhoneNumber,
            request.Email, request.Latitude, request.Longitude, businessId);

        await _warehouseRepository.AddAsync(warehouse);
        await _warehouseRepository.SaveChangesAsync();

        return warehouse.Id;
    }
}