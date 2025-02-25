using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;
using Microsoft.EntityFrameworkCore;

namespace FleetManagement.Persistence.EF.Repositories.Customers;

public class CustomerQueryRepository : BaseQueryRepository<long, Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }

    public async Task<List<Branch>> GetBranchesByCustomerId(long customerId)
    {
        return await _dbSet.Where(c => c.Id == customerId)
                           .SelectMany(c => c.Branches)
                           .AsNoTracking()
                           .ToListAsync();
    }

    public async Task<Branch> GetSpecificBranchOfCustomer(long customerId, long branchId)
    {
        return await _dbSet.Where(c => c.Id == customerId)
                           .SelectMany(c => c.Branches)
                           .Where(b => b.Id == branchId)
                           .AsNoTracking()
                           .FirstOrDefaultAsync();
    }
}
