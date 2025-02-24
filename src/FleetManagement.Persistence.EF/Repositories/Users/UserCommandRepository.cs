using FleetManagement.Domain.Models.Users;
using FleetManagement.Domain.Models.Users.Repostitories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Users;

public class UserCommandRepository : BaseCommandRepository<long, User>, IUserCommandRepository
{
    public UserCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
