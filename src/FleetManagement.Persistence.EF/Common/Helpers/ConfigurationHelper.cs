using Microsoft.Extensions.Configuration;

namespace FleetManagement.Persistence.EF.Common.Helpers;

public class ConfigurationHelper
{
    public static IConfiguration Configuration;

    static ConfigurationHelper()
    {
        Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{GetEnvironment}.json", optional: false, reloadOnChange: true)
                .Build();
    }

    private static string GetEnvironment =>
                            Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ??
                            "Development";
}
