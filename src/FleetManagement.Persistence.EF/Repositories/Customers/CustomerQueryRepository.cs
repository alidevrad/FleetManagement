using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Customers;

public class CustomerQueryRepository : BaseQueryRepository<long, Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
