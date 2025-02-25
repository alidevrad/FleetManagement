using FleetManagement.Application.Contract.Customers.Commands;
using FleetManagement.Domain.Models.Customers.Repositories;
using MediatR;

namespace FleetManagement.Application.Customers.Commands;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand>
{
    private readonly ICustomerCommandRepository _customerCommandRepository;
    private readonly ICustomerQueryRepository _customerQueryRepository;

    public UpdateBranchCommandHandler(ICustomerCommandRepository customerCommandRepository,
                                      ICustomerQueryRepository customerQueryRepository)
    {
        _customerCommandRepository = customerCommandRepository;
        _customerQueryRepository = customerQueryRepository;
    }

    public async Task Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerQueryRepository.GetByIdAsync(request.CustomerId);
        if (customer is null)
            throw new Exception($"Customer with ID {request.CustomerId} not found.");

        var branch = customer.Branches.FirstOrDefault(b => b.Id == request.BranchId);
        if (branch is null)
            throw new Exception($"Branch with ID {request.BranchId} not found for Customer {request.CustomerId}.");

        branch.Update(
            request.Name,
            request.Latitude,
            request.Longitude,
            request.Address,
            request.AgentFullName,
            request.AgentPhoneNumber
        );

        _customerCommandRepository.Update(customer);
        await _customerCommandRepository.SaveChangesAsync();
    }
}
