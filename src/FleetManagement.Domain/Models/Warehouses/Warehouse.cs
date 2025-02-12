using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Warehouses;

public class Warehouse : AuditableAggregateRoot<long>
{
    protected Warehouse() : base(Guid.NewGuid())
    {
    }

    public Warehouse(string name,
                     string street,
                     string city,
                     string state,
                     string postalCode,
                     string country,
                     PhoneNumber phoneNumber,
                     string email,
                     double latitude,
                     double longitude,
                     Guid businessId) : base(businessId)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        PhoneNumber = phoneNumber;
        Email = email;
        Latitude = latitude;
        Longitude = longitude;
        IsActive = true;
    }


    #region Properties

    public string Name { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public bool IsActive { get; private set; }

    #endregion

    #region Constructors


    #endregion

    #region Methods

    public void Activate()
    {
        if (IsActive) throw new InvalidOperationException("Warehouse is already active.");

        IsActive = true;
    }

    public void Deactivate()
    {
        if (!IsActive) throw new InvalidOperationException("Warehouse is already deactive.");

        IsActive = false;
    }

    public void Update(string name, string street, string city, string state,
                       string postalCode, string country, PhoneNumber phoneNumber,
                       string email, double latitude, double longitude)
    {
        Name = name;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        PhoneNumber = phoneNumber;
        Email = email;
        Latitude = latitude;
        Longitude = longitude;
    }

    #endregion
}
