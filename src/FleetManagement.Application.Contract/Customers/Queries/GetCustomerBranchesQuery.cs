using FleetManagement.Domain.Models.Customers;
using MediatR;

public record GetCustomerBranchesQuery(long CustomerId) : IRequest<List<Branch>>;