using FleetManagement.Domain.Common.Repositories.Queries;

namespace FleetManagement.Domain.Models.Customers.Repositories;

public interface ICustomerQueryRepository : IQueryRepository<long, Customer>
{
}
