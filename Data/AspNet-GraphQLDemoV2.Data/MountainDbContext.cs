using AspNet_GraphQLDemoV2.Common.Types.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AspNet_GraphQLDemoV2.Data
{
    public class MountainDbContext : DbContext
    {

        public MountainDbContext(DbContextOptions<MountainDbContext> options) : base(options)
        {

        }

        public DbSet<Mountain> Mountains { get; set; }

    }
}