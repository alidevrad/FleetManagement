using FleetManagement.Domain.Models.Customers;
using MediatR;

namespace FleetManagement.Application.Contract.Customers.Queries;

public record GetAllCustomersQuery() : IRequest<List<Customer>>;