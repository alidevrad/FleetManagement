using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public UpdateCustomerCommandHandler(ICustomerCommandRepository customerRepository,
                                        ICustomerQueryRepository customerQueryRepository)
    {
        _customerRepository = customerRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.Id);

        if (customer == null) throw new InvalidOperationException("Customer not found.");

        customer.Update(
            request.StoreName,
            request.StoreOwnerName,
            request.TaxNumber,
            request.Latitude,
            request.Longitude,
            request.Email
        );

        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
