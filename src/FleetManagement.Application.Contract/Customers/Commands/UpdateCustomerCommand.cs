using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Customers.Commands;

public record UpdateCustomerCommand(
       long Id,
       string StoreName,
       string StoreOwnerName,
       string TaxNumber,
       double Latitude,
       double Longitude,
       string Email
   ) : ICommand;
