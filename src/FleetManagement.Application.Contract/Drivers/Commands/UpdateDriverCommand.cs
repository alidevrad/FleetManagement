using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Models.Drivers.Enums;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record UpdateDriverCommand(long Id,
                                  string FirstName,
                                  string LastName,
                                  Gender Gender,
                                  PhoneNumber PhoneNumber,
                                  string Address,
                                  DateTime DateOfBirth,
                                  string LicenseType,
                                  string NativeLanguage,
                                  DateTime LicenseIssueDate,
                                  DateTime LicenseExpirationDate,
                                  string ImageUrl) : ICommand;
