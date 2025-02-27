﻿using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Drivers.Commands;

public record ReserveDriverCommand(long Id, DateTime Start, DateTime End) : ICommand<long>;
