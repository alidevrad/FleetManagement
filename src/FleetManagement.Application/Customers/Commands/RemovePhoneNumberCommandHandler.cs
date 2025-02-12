﻿using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class RemovePhoneNumberCommandHandler : IRequestHandler<RemovePhoneNumberCommand>
{
    private readonly ICustomerCommandRepository _customerRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public RemovePhoneNumberCommandHandler(ICustomerCommandRepository customerRepository,
                                           ICustomerQueryRepository customerQueryRepository)
    {
        _customerRepository = customerRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(RemovePhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
            throw new InvalidOperationException("Customer not found.");

        customer.RemovePhoneNumber(request.Number);

        _customerRepository.Update(customer);
        await _customerRepository.SaveChangesAsync();
    }
}
