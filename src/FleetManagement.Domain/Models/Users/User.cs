using FleetManagement.Domain.Common.BuildingBlocks.Core;

namespace FleetManagement.Domain.Models.Users;

public class User : AuditableAggregateRoot<long>
{
    protected User() : base(Guid.NewGuid()) { }

    public User(string userName,
                string firstName,
                string lastName,
                string email,
                string passwordHash,
                string passwordSalt,
                DateTime registerDate,
                Guid businessId) : base(businessId)
    {
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        RegisterDate = registerDate;
        LastLoginDate = DateTime.MinValue;
        IsActive = true;
    }

    public string UserName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public DateTime LastLoginDate { get; private set; }
    public bool IsActive { get; private set; }

    public void UpdateLastLoginDate()
    {
        LastLoginDate = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
