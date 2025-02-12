using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static FleetManagement.Persistence.EF.Common.Helpers.ConfigurationHelper;

namespace FleetManagement.Persistence.EF.DbContextes
{
    public class FleetManagementDbContextFactory : IDesignTimeDbContextFactory<FleetManagementDbContext>
    {
        public FleetManagementDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FleetManagementDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("DbConnection"));

            return new FleetManagementDbContext(builder.Options);
        }
    }
}
