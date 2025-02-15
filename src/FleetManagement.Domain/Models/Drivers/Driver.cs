using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Drivers.Enums;
using FleetManagement.Domain.Models.Drivers.Events;
using FleetManagement.Domain.Models.Shared;

namespace FleetManagement.Domain.Models.Drivers;

public class Driver : AuditableAggregateRoot<long>
{
    #region Properties

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Gender Gender { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string LicenseType { get; private set; }
    public DateTime LicenseIssueDate { get; private set; }
    public DateTime LicenseExpirationDate { get; private set; }
    public string NativeLanguage { get; private set; }

    private readonly List<TrainingQualification> _trainingQualifications = new();
    public IReadOnlyList<TrainingQualification> TrainingQualifications => _trainingQualifications.AsReadOnly();

    private readonly List<EmergencyContact> _emergencyContacts = new();
    public IReadOnlyList<EmergencyContact> EmergencyContacts => _emergencyContacts.AsReadOnly();

    private readonly List<ReservationPeriod> _reservationPeriods = new();
    public IReadOnlyList<ReservationPeriod> ReservationPeriods => _reservationPeriods.AsReadOnly();

    public bool IsActive { get; private set; }

    #endregion

    #region Constructors

    protected Driver() : base(Guid.NewGuid()) { }

    public Driver(
        string firstName,
        string lastName,
        Gender gender,
        PhoneNumber phoneNumber,
        string address,
        DateTime dateOfBirth,
        string licenseType,
        string nativeLanguage,
        DateTime licenseIssueDate,
        DateTime licenseExpirationDate,
        Guid businessId
        )
        : base(businessId)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Address = address;
        DateOfBirth = dateOfBirth;
        LicenseType = licenseType;
        LicenseIssueDate = licenseIssueDate;
        LicenseExpirationDate = licenseExpirationDate;
        IsActive = true;
        NativeLanguage = nativeLanguage;
    }

    #endregion

    #region Methods

    public bool IsAvailableForPeriod(DateTime start, DateTime end)
    {
        return !_reservationPeriods.Any(r => r.Status == ReservationStatus.Active && r.Overlaps(start, end));
    }

    public bool IsCurrentlyAvailable()
    {
        var now = DateTime.UtcNow;
        return !_reservationPeriods.Any(r => r.Status == ReservationStatus.Active && now >= r.Start && now < r.End);
    }

    public void Reserve(DateTime start, DateTime end)
    {
        if (!IsAvailableForPeriod(start, end))
            throw new InvalidOperationException("The selected time period overlaps with an existing reservation.");

        var reservation = new ReservationPeriod(start, end);
        _reservationPeriods.Add(reservation);
    }

    public void Release(long reservationId)
    {
        var reservation = _reservationPeriods.FirstOrDefault(r => r.Id == reservationId);
        if (reservation == null)
            throw new InvalidOperationException("Reservation not found.");

        if (reservation.Status == ReservationStatus.Cancelled)
            throw new InvalidOperationException("Reservation is already cancelled.");

        reservation.Cancel();
    }

    public void CompleteReservation(long reservationId)
    {
        var reservation = _reservationPeriods.FirstOrDefault(r => r.Id == reservationId);
        if (reservation == null)
            throw new InvalidOperationException("Reservation not found.");

        reservation.Finish();
    }

    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("Driver is already active.");

        IsActive = true;
        AddDomainEvent(new DriverActivated(BusinessId, Id));
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Driver is already inactive.");

        IsActive = false;
        AddDomainEvent(new DriverDeactivated(BusinessId, Id));
    }

    public void AddEmergencyContact(string name, string relationship, string phoneNumber)
    {
        _emergencyContacts.Add(new EmergencyContact(name, relationship, phoneNumber));
    }

    public void AddTrainingQualification(string qualificationName, DateTime? obtainedDate = null, DateTime? expirationDate = null)
    {
        _trainingQualifications.Add(new TrainingQualification(qualificationName, obtainedDate, expirationDate));
    }

    public void Update(
    string firstName,
    string lastName,
    Gender gender,
    PhoneNumber phoneNumber,
    string address,
    DateTime dateOfBirth,
    string licenseType,
    string nativeLanguage,
    DateTime licenseIssueDate,
    DateTime licenseExpirationDate
    )
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PhoneNumber = phoneNumber;
        Address = address;
        DateOfBirth = dateOfBirth;
        LicenseType = licenseType;
        LicenseIssueDate = licenseIssueDate;
        LicenseExpirationDate = licenseExpirationDate;
        NativeLanguage = nativeLanguage;
    }

    #endregion
}