using FleetManagement.Application.Contract.Drivers.Commands;
using FleetManagement.Application.Contract.Resources.Commands;
using FleetManagement.Application.Contract.Trips.Commands;
using FleetManagement.Application.Contract.Vehicles.Commands;
using FleetManagement.Domain.Models.Drivers;
using FleetManagement.Domain.Models.Trips;
using FleetManagement.Domain.Models.Trips.Repositories;
using FleetManagement.Domain.Models.Vehicles;
using FleetManagement.Infrastructure.GoogleMaps;
using MediatR;

public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, long>
{
    private readonly ITripCommandRepository _tripRepository;
    private readonly IGoogleMapService _googleMapsService;
    private readonly IMediator _mediator;

    public CreateTripCommandHandler(IMediator mediator,
                                    ITripCommandRepository tripRepository,
                                    IGoogleMapService googleMapsService)
    {
        _mediator = mediator;
        _tripRepository = tripRepository;
        _googleMapsService = googleMapsService;
    }

    public async Task<long> Handle(CreateTripCommand request, CancellationToken cancellationToken)
    {
        long driverReservationId = 0;
        long vehicleReservationId = 0;

        // 🚀 مرحله 1: محاسبه مسیر بهینه از Google API
        var routeData = await _googleMapsService.CalculateShortestRouteAsync(request.SubTrips)
                        ?? throw new Exception("Failed to calculate route.");

        var estimatedEndTime = routeData.EstimatedEndTime;

        // 🚀 مرحله 2: قفل کردن راننده از طریق MediatR
        var driverLocked = await _mediator.Send(new LockResourceCommand(request.DriverId,
                                                                        typeof(Driver).Name,
                                                                        request.StartDateTime,
                                                                        estimatedEndTime), cancellationToken);
        if (!driverLocked)
            throw new Exception("Driver is not available.");

        try
        {
            // 🚀 مرحله 3: قفل کردن وسیله نقلیه از طریق MediatR
            var vehicleLocked = await _mediator.Send(new LockResourceCommand(request.VehicleId,
                                                                             typeof(Vehicle).Name,
                                                                             request.StartDateTime,
                                                                             estimatedEndTime), cancellationToken);
            if (!vehicleLocked)
            {
                await _mediator.Send(new RollbackResourceReservationCommand(request.DriverId, request.BusinessId), cancellationToken);
                throw new Exception("Vehicle is not available.");
            }

            try
            {
                // ایجاد Aggregate Root سفر
                var trip = new Trip(
                    request.TripName,
                    request.StartDateTime,
                    request.DriverId,
                    request.VehicleId,
                    request.BusinessId
                );

                // پردازش هر SubTrip موجود در Command
                foreach (var subTripCmd in request.SubTrips)
                {
                    var deliveryPoint = new DeliveryPoint(
                        subTripCmd.DeliveryPoint.BranchId,
                        subTripCmd.DeliveryPoint.Order,
                        subTripCmd.DeliveryPoint.Address,
                        subTripCmd.DeliveryPoint.Latitude,
                        subTripCmd.DeliveryPoint.Longitude
                    );

                    var subTrip = new SubTrip(
                        trip.Id,
                        subTripCmd.Origin,
                        deliveryPoint,
                        subTripCmd.RouteDetails,
                        subTripCmd.EstimatedDuration,
                        subTripCmd.FuelConsumption,
                        subTripCmd.DelayTimeValue
                    );

                    trip.AddSubTrip(subTrip);
                }

                trip.CalculateTotalDelayTime();
                trip.CalculateTotalFuelConsumption();
                trip.CalculateTotalTripDuration();

                await _tripRepository.AddAsync(trip);
                await _tripRepository.SaveChangesAsync();

                driverReservationId = await _mediator.Send(new ReserveDriverCommand(request.DriverId, request.StartDateTime, estimatedEndTime));
                vehicleReservationId = await _mediator.Send(new ReserveVehicleCommand(request.DriverId, request.StartDateTime, estimatedEndTime));

                return trip.Id;

                // return Result<long>.Success(trip.Id);
            }
            catch (Exception ex)
            {
                await _mediator.Send(new RollbackDriverReservationCommand(request.DriverId, driverReservationId), cancellationToken);
                await _mediator.Send(new RollbackVehicleReservationCommand(request.VehicleId, vehicleReservationId), cancellationToken);

                await _mediator.Send(new RollbackResourceReservationCommand(request.DriverId, request.BusinessId), cancellationToken);
                await _mediator.Send(new RollbackResourceReservationCommand(request.VehicleId, request.BusinessId), cancellationToken);

                throw;
            }
        }
        catch
        {
            await _mediator.Send(new RollbackResourceReservationCommand(request.DriverId, request.BusinessId), cancellationToken);
            throw;
        }
    }
}

