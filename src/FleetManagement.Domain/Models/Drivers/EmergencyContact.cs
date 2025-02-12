namespace FleetManagement.Domain.Models.Drivers;

public class EmergencyContact
{
    public string Name { get; private set; }
    public string Relationship { get; private set; }
    public string PhoneNumber { get; private set; }

    protected EmergencyContact() { }

    public EmergencyContact(string name, string relationship, string phoneNumber)
    {
        Name = name;
        Relationship = relationship;
        PhoneNumber = phoneNumber;
    }
}
