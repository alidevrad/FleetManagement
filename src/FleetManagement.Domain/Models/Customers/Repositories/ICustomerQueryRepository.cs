using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Customers.Repositories;

public interface ICustomerQueryRepository : IQueryRepository<long, Customer>
{
    Task<List<Branch>> GetBranchesByCustomerId(long customerId);

    Task<Branch> GetSpecificBranchOfCustomer(long customerId, long branchId);
}
