using FleetManagement.Domain.Models.Customers;
using MediatR;

namespace FleetManagement.Application.Contract.Customers.Queries;

public record GetSpecificBranchOfCustomerQuery(long CustomerId, long BranchId) : IRequest<Branch>;

