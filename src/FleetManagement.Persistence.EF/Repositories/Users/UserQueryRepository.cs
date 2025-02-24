using FleetManagement.Domain.Models.Users;
using FleetManagement.Domain.Models.Users.Repostitories;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FleetManagement.Persistence.EF.Repositories.Users;

public class UserQueryRepository : BaseQueryRepository<long, User>, IUserQueryRepository
{
    public UserQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }

    public async Task<User> GetByExpressionAsync(Expression<Func<User, bool>> predicate)
    {
        return await _context.Users.FirstOrDefaultAsync(predicate);
    }
}
