using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Customers;

public class Branch : AuditableEntity<long>
{
    #region Properties

    public long CustomerId { get; private set; }

    public string Name { get; private set; }

    public double Latitude { get; private set; }

    public double Longitude { get; private set; }

    public bool IsActive { get; private set; }

    public string Address { get; private set; }

    public string AgentFullName { get; private set; }

    public PhoneNumber AgentPhoneNumber { get; private set; }

    private readonly List<PhoneNumber> _phoneNumbers = new();
    public IReadOnlyList<PhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();

    #endregion

    #region Constructors

    protected Branch() { }

    public Branch(long customerId,
                  string name,
                  double latitude,
                  double longitude,
                  List<PhoneNumber> phoneNumbers,
                  string address,
                  string agentFullName,
                  PhoneNumber agentPhoneNumber)
    {
        CustomerId = customerId;
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        IsActive = true;
        //TODO: TemporaryId = Guid.NewGuid(); // Assign temporary ID for BranchAdded domain event instead of relying on database-generated IDs
        _phoneNumbers = phoneNumbers ?? throw new ArgumentNullException(nameof(phoneNumbers));
        Address = address;
        AgentFullName = agentFullName;
        AgentPhoneNumber = agentPhoneNumber;
    }

    #endregion

    #region Methods

    public void Activate()
    {
        if (IsActive)
            throw new InvalidOperationException("Branch is already active.");

        IsActive = true;
    }

    public void Deactivate()
    {
        if (!IsActive)
            throw new InvalidOperationException("Branch is already inactive.");

        IsActive = false;
    }

    public void AddPhoneNumber(string countryCode, string number, string title)
    {
        if (_phoneNumbers.Any(p => p.Number == number))
            throw new InvalidOperationException("Phone number already exists.");

        _phoneNumbers.Add(new PhoneNumber(countryCode, number, title));
    }

    public void RemovePhoneNumber(string number)
    {
        var phone = _phoneNumbers.FirstOrDefault(p => p.Number == number);
        if (phone is null) throw new InvalidOperationException("Phone number not found.");

        _phoneNumbers.Remove(phone);
    }

    public void Update(
                   string name,
                   double latitude,
                   double longitude,
                   string address,
                   string agentFullName,
                   PhoneNumber agentPhoneNumber)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
        Address = address;
        AgentFullName = agentFullName;
        AgentPhoneNumber = agentPhoneNumber;
    }

    #endregion
}
