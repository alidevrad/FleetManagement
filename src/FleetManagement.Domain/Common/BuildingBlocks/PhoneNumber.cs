namespace FleetManagement.Domain.Common.BuildingBlocks;

public class PhoneNumber
{
    public string CountryCode { get; private set; }
    public string Number { get; private set; }
    public string Title { get; private set; }
    public override string ToString() => $"{CountryCode} {Number} - {Title}";

    public PhoneNumber(string countryCode, string number, string title)
    {
        CountryCode = countryCode;
        Number = number;
        Title = title;
    }

    public static PhoneNumber Create(string countryCode, string number, string title)
    {
        if (string.IsNullOrWhiteSpace(countryCode) || string.IsNullOrWhiteSpace(number))
            throw new ArgumentException("Invalid phone number format.");

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is empty.");

        return new PhoneNumber(countryCode, number, title);
    }
}
