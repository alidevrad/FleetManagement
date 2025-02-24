namespace FleetManagement.Infrastructure.Authentication.Configurations;

public class AuthConfig
{
    public string TokenKey { get; set; } = string.Empty;
    public int TokenTimeout { get; set; } = 120; // مقدار پیش‌فرض 120 دقیقه

    public AuthConfig()
    {
    }
}
