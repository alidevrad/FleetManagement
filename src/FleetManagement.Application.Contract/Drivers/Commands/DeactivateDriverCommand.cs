﻿using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record DeactivateDriverCommand(long Id) : ICommand;
