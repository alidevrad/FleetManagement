using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Users.Repostitories;

public interface IUserCommandRepository : ICommandRepository<long, User>
{
}
