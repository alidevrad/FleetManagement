using FleetManagement.Domain.Common.BuildingBlocks;
using FleetManagement.Domain.Common.BuildingBlocks.Core;
using FleetManagement.Domain.Models.Customers.Events;

namespace FleetManagement.Domain.Models.Customers;

public class Customer : AuditableAggregateRoot<long>
{
    #region Properties

    public string StoreName { get; private set; }
    public string StoreOwnerName { get; private set; }
    public string TaxNumber { get; private set; }

    //TODO: Should be optional
    public double Latitude { get; private set; }

    //TODO: Should be optional
    public double Longitude { get; private set; }

    public string Email { get; private set; }


    private readonly List<Branch> _branches = new();
    public IReadOnlyList<Branch> Branches => _branches.AsReadOnly();

    private readonly List<PhoneNumber> _phoneNumbers = new();
    public IReadOnlyList<PhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();

    #endregion

    #region Constructors

    protected Customer() : base(Guid.NewGuid()) { }

    public Customer(string storeName,
                    string storeOwnerName,
                    string taxNumber,
                    double latitude,
                    double longitude,
                    List<PhoneNumber> phoneNumbers,
                    string email,
                    Guid businessId
                    )
        : base(businessId)
    {
        StoreName = storeName;
        StoreOwnerName = storeOwnerName;
        TaxNumber = taxNumber;
        Latitude = latitude;
        Longitude = longitude;
        _phoneNumbers = phoneNumbers ?? throw new ArgumentNullException(nameof(phoneNumbers));
        Email = email;
    }

    #endregion

    public void AddBranch(string name,
                          double latitude,
                          double longitude,
                          List<PhoneNumber> phoneNumbers,
                          string address,
                          string agentFullName,
                          PhoneNumber agentPhoneNumber)
    {
        var branch = new Branch(Id,
                                name,
                                latitude,
                                longitude,
                                phoneNumbers,
                                address,
                                agentFullName,
                                agentPhoneNumber);

        _branches.Add(branch);

        // TODO: Use Guid for Branch ID generation instead of relying on database-generated IDs in the future.
        // branch.Id
        //TODO: AddDomainEvent(new BranchAdded(BusinessId, Id, branch.Id, branch.Name));
    }

    public void RemoveBranch(long branchId)
    {
        var branch = _branches.FirstOrDefault(b => b.Id == branchId);
        if (branch is null) throw new InvalidOperationException("Branch not found.");

        _branches.Remove(branch);

        AddDomainEvent(new BranchRemoved(BusinessId, Id, branchId));
    }

    public void ActivateBranch(long branchId)
    {
        var branch = _branches.FirstOrDefault(b => b.Id == branchId);
        if (branch is null) throw new InvalidOperationException("Branch not found.");

        branch.Activate();

        AddDomainEvent(new BranchActivated(BusinessId, Id, branchId));
    }

    public void DeactivateBranch(long branchId)
    {
        var branch = _branches.FirstOrDefault(b => b.Id == branchId);
        if (branch is null) throw new InvalidOperationException("Branch not found.");

        branch.Deactivate();

        AddDomainEvent(new BranchDeactivated(BusinessId, Id, branchId));
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
                    string storeName,
                    string storeOwnerName,
                    string taxNumber,
                    double latitude,
                    double longitude,
                    string email
                    )
    {
        StoreName = storeName;
        StoreOwnerName = storeOwnerName;
        TaxNumber = taxNumber;
        Latitude = latitude;
        Longitude = longitude;
        Email = email;
    }
}
