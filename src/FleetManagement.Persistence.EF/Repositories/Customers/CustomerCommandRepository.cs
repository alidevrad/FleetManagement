using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using FleetManagement.Persistence.EF.DbContextes;

namespace FleetManagement.Persistence.EF.Repositories.Customers;

public class CustomerCommandRepository : BaseCommandRepository<long, Customer>, ICustomerCommandRepository
{
    public CustomerCommandRepository(FleetManagementDbContext context) : base(context)
    {
    }
}
