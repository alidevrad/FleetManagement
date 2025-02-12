using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.VehicleTypes;

public class VehicleTypeCommandRepository : BaseCommandRepository<long, VehicleType>, IVehicleTypeCommandRepository
{
    public VehicleTypeCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
