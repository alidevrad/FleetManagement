﻿using FleetManagement.Application.Contract.Common.Messaging;

namespace FleetManagement.Application.Contract.Vehicles.Commands;

public record ReserveVehicleCommand(long Id, DateTime Start, DateTime End) : ICommand<long>;