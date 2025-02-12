using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly ICustomerCommandRepository _customerRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public DeleteCustomerCommandHandler(ICustomerCommandRepository customerRepository,
                                        ICustomerQueryRepository customerQueryRepository)
    {
        _customerRepository = customerRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.Id);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        _customerRepository.Delete(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
