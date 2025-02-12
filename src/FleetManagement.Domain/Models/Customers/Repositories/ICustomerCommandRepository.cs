using FleetManagement.Domain.Common.Repositories.Commands;

namespace FleetManagement.Domain.Models.Customers.Repositories;

public interface ICustomerCommandRepository : ICommandRepository<long, Customer>
{
}
