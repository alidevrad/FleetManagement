using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Drivers.Enums;
using FleetManagement.Domain.Models.Drivers.Events;

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

    public bool IsAvailable { get; private set; }
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
        IsAvailable = true;
        IsActive = true;
        NativeLanguage = nativeLanguage;
    }

    #endregion

    #region Methods

    //TODO: Should reserve in a range time
    public void Reserve()
    {
        if (!IsAvailable)
            throw new InvalidOperationException("Driver is already reserved or unavailable.");

        IsAvailable = false;
        AddDomainEvent(new DriverReserved(BusinessId, Id));
    }

    public void Release()
    {
        if (IsAvailable)
            throw new InvalidOperationException("Driver is already available.");

        IsAvailable = true;
        AddDomainEvent(new DriverReleased(BusinessId, Id));
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