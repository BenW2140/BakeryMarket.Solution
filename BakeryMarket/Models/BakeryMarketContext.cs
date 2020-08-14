using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakeryMarket.Models
{
  public class BakeryMarketContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Flavor> Flavors { get; set; }

    public DbSet<Treat> Treats { get; set; }

    public DbSet<FlavorTreat> FlavorTreat { get; set; }

    public BakeryMarketContext(DbContextOptions options) : base(options) {}
  }
}