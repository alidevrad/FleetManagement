using FleetManagement.Application.Contract.Common.Messaging;
using FleetManagement.Domain.Models.Trips.Enums;

namespace FleetManagement.Application.Contract.Trips.Commands;

/// <summary>
/// فرمان ایجاد یک سفر جدید
/// </summary>
public record CreateTripCommand(
    string TripName,
    DateTime StartDateTime,
    long DriverId,
    long VehicleId,
    List<CreateSubTripDto> SubTrips,            // لیست زیرسفرها
    double TotalDelayTime,                      // مجموع زمان‌های تأخیر (دقیقه)
    double TotalTripDuration,                   // مجموع مدت‌زمان سفر (دقیقه)
    double TotalFuelConsumption,                // مجموع مصرف سوخت سفر (لیتر)
    Guid BusinessId                             // شناسه‌ی تجاری (برای traceability)
) : ICommand<long>;

/// <summary>
/// DTO برای زیرسفرهای یک سفر
/// </summary>
public record CreateSubTripDto(
    string Origin,            // مبدا
    DeliveryPointDto DeliveryPoint, // مقصد
    string? RouteDetails,     // اطلاعات مسیر (optional)
    TimeSpan EstimatedDuration, // مدت زمان تخمینی زیرسفر
    DateTime? EndTime,        // زمان پایان (nullable)
    SubTripStatus Status,     // وضعیت زیرسفر
    double FuelConsumption,   // مصرف سوخت زیرسفر
    double DelayTimeValue     // میزان تأخیر در زیرسفر
);

/// <summary>
/// DTO برای مقصد زیرسفر
/// </summary>
public record DeliveryPointDto(
    long BranchId,
    int Order,
    string Address,
    double Latitude,
    double Longitude
);
