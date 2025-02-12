using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class AddPhoneNumberCommandHandler : IRequestHandler<AddPhoneNumberCommand>
{
    private readonly ICustomerCommandRepository _customerRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public AddPhoneNumberCommandHandler(ICustomerCommandRepository customerRepository,
                                        ICustomerQueryRepository customerQueryRepository)
    {
        _customerRepository = customerRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(AddPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        customer.AddPhoneNumber(request.CountryCode, request.Number, request.Title);

        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
