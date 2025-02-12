using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class AddBranchCommandHandler : IRequestHandler<AddBranchCommand>
{
    private readonly ICustomerCommandRepository _customerRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public AddBranchCommandHandler(ICustomerCommandRepository customerRepository,
                                   ICustomerQueryRepository customerQueryRepository)
    {
        _customerRepository = customerRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(AddBranchCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        customer.AddBranch(request.Name,
                           request.Latitude,
                           request.Longitude,
                           request.PhoneNumbers,
                           request.Address,
                           request.AgentFullName,
                           request.AgentPhoneNumber);

        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
