using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.VehicleTypes.Enums;

namespace FleetManagement.Domain.Models.VehicleTypes;

public class VehicleType : AuditableAggregateRoot<long>
{
    public string Name { get; private set; }  // "Light Truck", "Cargo Van", etc.
    public VehicleCategory Category { get; private set; }  // Truck, Car, Motorcycle, etc.
    public decimal MaxWeightCapacity { get; private set; }  // Max load capacity in KG
    public decimal MaxVolumeCapacity { get; private set; }  // Cargo space in cubic meters
    public FuelType FuelType { get; private set; }  // Diesel, Electric, etc.
    public double AverageFuelConsumption { get; private set; }  // Fuel usage per 100 km
    public string RequiredLicenseType { get; private set; }  // "C", "B", "D", etc.
    public bool IsRefrigerated { get; private set; }  // For cold storage
    public bool IsHazardousMaterialApproved { get; private set; }  // Can carry hazardous materials?
    public int MaxSpeedLimit { get; private set; }  // Speed limit enforcement
    public int NumberOfWheels { get; private set; }  // Two, Four, Six, etc.

    protected VehicleType() : base(Guid.NewGuid()) { }

    public VehicleType(string name,
                       VehicleCategory category,
                       decimal maxWeightCapacity,
                       decimal maxVolumeCapacity,
                       FuelType fuelType,
                       double averageFuelConsumption,
                       string requiredLicenseType,
                       bool isRefrigerated,
                       bool isHazardousMaterialApproved,
                       int maxSpeedLimit,
                       int numberOfWheels,
                       Guid businessId) : base(businessId)
    {
        Name = name;
        Category = category;
        MaxWeightCapacity = maxWeightCapacity;
        MaxVolumeCapacity = maxVolumeCapacity;
        FuelType = fuelType;
        AverageFuelConsumption = averageFuelConsumption;
        RequiredLicenseType = requiredLicenseType;
        IsRefrigerated = isRefrigerated;
        IsHazardousMaterialApproved = isHazardousMaterialApproved;
        MaxSpeedLimit = maxSpeedLimit;
        NumberOfWheels = numberOfWheels;
    }

    public void Update(string name,
                       VehicleCategory category,
                       decimal maxWeightCapacity,
                       decimal maxVolumeCapacity,
                       FuelType fuelType,
                       double averageFuelConsumption,
                       string requiredLicenseType,
                       bool isRefrigerated,
                       bool isHazardousMaterialApproved,
                       int maxSpeedLimit,
                       int numberOfWheels)
    {
        Name = name;
        Category = category;
        MaxWeightCapacity = maxWeightCapacity;
        MaxVolumeCapacity = maxVolumeCapacity;
        FuelType = fuelType;
        AverageFuelConsumption = averageFuelConsumption;
        RequiredLicenseType = requiredLicenseType;
        IsRefrigerated = isRefrigerated;
        IsHazardousMaterialApproved = isHazardousMaterialApproved;
        MaxSpeedLimit = maxSpeedLimit;
        NumberOfWheels = numberOfWheels;
    }
}
