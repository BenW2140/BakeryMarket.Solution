using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BakeryMarket.Models
{
  public class BakeryMarketContextFactory : IDesignTimeDbContextFactory<BakeryMarketContext>
  {

    BakeryMarketContext IDesignTimeDbContextFactory<BakeryMarketContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<BakeryMarketContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new BakeryMarketContext(builder.Options);
    }
  }
}