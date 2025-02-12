using FleetManagement.Domain.Models.VehicleTypes;
using FleetManagement.Domain.Models.VehicleTypes.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.VehicleTypes;

public class VehicleTypeQueryRepository : BaseQueryRepository<long, VehicleType>, IVehicleTypeQueryRepository
{
    public VehicleTypeQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
