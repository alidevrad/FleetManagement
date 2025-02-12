using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Vehicles;

public class VehicleCommandRepository : BaseCommandRepository<long, Vehicle>, IVehicleCommandRepository
{
    public VehicleCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
