using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Common.BuildingBlocks;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record CreateCustomerCommand(
        string StoreName,
        string StoreOwnerName,
        string TaxNumber,
        double Latitude,
        double Longitude,
        List<PhoneNumber> PhoneNumbers,
        string Email
    ) : ICommand<long>;
