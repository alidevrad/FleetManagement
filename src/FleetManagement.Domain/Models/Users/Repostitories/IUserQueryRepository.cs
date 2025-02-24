using FleetManagement.Domain.Common.Repositories.Queries;
using System.Linq.Expressions;

namespace FleetManagement.Domain.Models.Users.Repostitories;

public interface IUserQueryRepository : IQueryRepository<long, User>
{
    Task<User> GetByExpressionAsync(Expression<Func<User, bool>> predicate);
}