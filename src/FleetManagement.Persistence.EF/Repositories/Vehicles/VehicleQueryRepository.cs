using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Domain.Models.Vehicles.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Vehicles;

public class VehicleQueryRepository : BaseQueryRepository<long, Vehicle>, IVehicleQueryRepository
{
    public VehicleQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
