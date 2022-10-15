using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AspNet_GraphQLDemoV2.Data
{
    public class MountainContextContextFactory : IDesignTimeDbContextFactory<MountainDbContext>
    {
        public MountainDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();


            // Here we create the DbContextOptionsBuilder manually.        
            var builder = new DbContextOptionsBuilder<MountainDbContext>();

            // Build connection string. This requires that you have a connectionstring in the appsettings.json
            var connectionString = configuration.GetConnectionString("MountainsV2Db");
            builder.UseSqlServer(connectionString);
            // Create our DbContext.
            return new MountainDbContext(builder.Options);
        }

    }
}