using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    private readonly ICustomerCommandRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerCommandRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var businessId = Guid.NewGuid();

        var customer = new Customer(
            request.StoreName,
            request.StoreOwnerName,
            request.TaxNumber,
            request.Latitude,
            request.Longitude,
            request.PhoneNumbers,
            request.Email,
            businessId
        );

        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync();

        return customer.Id;
    }
}
