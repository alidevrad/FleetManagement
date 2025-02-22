//TODO: Next phase

//using FleetManagement.Application.Contract.Drivers.Commands;
//using FleetManagement.Application.Contract.Resources.Commands;
//using FleetManagement.Application.Contract.Trips.Commands;
//using FleetManagement.Application.Contract.Vehicles.Commands;
//using FleetManagement.Domain.Models.Drivers;
//using FleetManagement.Domain.Models.Trips;
//using FleetManagement.Domain.Models.Trips.Repositories;
//using FleetManagement.Domain.Models.Vehicles;
//using FleetManagement.Infrastructure.GoogleMaps;
//using MediatR;

//public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, long>
//{
//    private readonly ITripCommandRepository _tripRepository;
//    private readonly IGoogleMapService _googleMapsService;
//    private readonly IMediator _mediator;

//    public CreateTripCommandHandler(IMediator mediator,
//                                    ITripCommandRepository tripRepository,
//                                    IGoogleMapService googleMapsService)
//    {
//        _mediator = mediator;
//        _tripRepository = tripRepository;
//        _googleMapsService = googleMapsService;
//    }

//    public async Task<long> Handle(CreateTripCommand request, CancellationToken cancellationToken)
//    {
//        var routeData = await _googleMapsService.CalculateShortestRouteAsync(request.SubTrips);
//        if (routeData == null)
//            throw new Exception("Failed to calculate route.");

//        var estimatedEndTime = routeData.EstimatedEndTime;

//        var (driverReservationId, vehicleReservationId) = await LockResources(request, estimatedEndTime, cancellationToken);

//        try
//        {
//            var trip = CreateTripAggregate(request);
//            await _tripRepository.AddAsync(trip);
//            await _tripRepository.SaveChangesAsync();

//            (driverReservationId, vehicleReservationId) = await ReserveResources(request, estimatedEndTime, cancellationToken);
//            return trip.Id;
//        }
//        catch
//        {
//            await RollbackResources(request, driverReservationId, vehicleReservationId, cancellationToken);
//            throw;
//        }
//    }

//    private async Task<(long driverReservationId, long vehicleReservationId)> LockResources(CreateTripCommand request, DateTime estimatedEndTime, CancellationToken cancellationToken)
//    {
//        var driverLocked = await _mediator.Send(new LockResourceCommand(request.DriverId, typeof(Driver).Name, request.StartDateTime, estimatedEndTime), cancellationToken);
//        if (!driverLocked)
//            throw new Exception("Driver is not available.");

//        var vehicleLocked = await _mediator.Send(new LockResourceCommand(request.VehicleId, typeof(Vehicle).Name, request.StartDateTime, estimatedEndTime), cancellationToken);
//        if (!vehicleLocked)
//        {
//            await _mediator.Send(new RollbackResourceReservationCommand(request.DriverId, request.BusinessId), cancellationToken);
//            throw new Exception("Vehicle is not available.");
//        }

//        return (0, 0); // Reservation IDs are initially 0, they will be updated after reservation
//    }

//    private Trip CreateTripAggregate(CreateTripCommand request)
//    {
//        var trip = new Trip(request.TripName, request.StartDateTime, request.DriverId, request.VehicleId, request.BusinessId);

//        foreach (var subTripCmd in request.SubTrips)
//        {
//            var deliveryPoint = new DeliveryPoint(
//                subTripCmd.DeliveryPoint.BranchId,
//                subTripCmd.DeliveryPoint.Order,
//                subTripCmd.DeliveryPoint.Address,
//                subTripCmd.DeliveryPoint.Latitude,
//                subTripCmd.DeliveryPoint.Longitude
//            );

//            var subTrip = new SubTrip(
//                trip.Id,
//                subTripCmd.Origin,
//                deliveryPoint,
//                subTripCmd.RouteDetails,
//                subTripCmd.EstimatedDuration,
//                subTripCmd.FuelConsumption,
//                subTripCmd.DelayTimeValue
//            );

//            trip.AddSubTrip(subTrip);
//        }

//        trip.CalculateTotalDelayTime();
//        trip.CalculateTotalFuelConsumption();
//        trip.CalculateTotalTripDuration();

//        return trip;
//    }

//    private async Task<(long driverReservationId, long vehicleReservationId)> ReserveResources(CreateTripCommand request, DateTime estimatedEndTime, CancellationToken cancellationToken)
//    {
//        var driverReservationId = await _mediator.Send(new ReserveDriverCommand(request.DriverId, request.StartDateTime, estimatedEndTime));
//        var vehicleReservationId = await _mediator.Send(new ReserveVehicleCommand(request.VehicleId, request.StartDateTime, estimatedEndTime));

//        return (driverReservationId, vehicleReservationId);
//    }

//    private async Task RollbackResources(CreateTripCommand request, long driverReservationId, long vehicleReservationId, CancellationToken cancellationToken)
//    {
//        if (driverReservationId > 0)
//        {
//            await _mediator.Send(new RollbackDriverReservationCommand(request.DriverId, driverReservationId), cancellationToken);
//        }
//        if (vehicleReservationId > 0)
//        {
//            await _mediator.Send(new RollbackVehicleReservationCommand(request.VehicleId, vehicleReservationId), cancellationToken);
//        }

//        await _mediator.Send(new RollbackResourceReservationCommand(request.DriverId, request.BusinessId), cancellationToken);
//        await _mediator.Send(new RollbackResourceReservationCommand(request.VehicleId, request.BusinessId), cancellationToken);
//    }
//}
