using Microsoft.EntityFrameworkCore;
using Models;

namespace DAO
{
    public class RuterEL : DbContext
    {
        DbSet<AppUser> appUser => Set<AppUser>();
        DbSet<Trip> trip => Set<Trip>();
        DbSet<Scooter> scooter => Set<Scooter>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            "Host = localhost:55434; " +
            "Username = postgres; " +
            "Password = pass; " +
            "Database = RuterEL;")
            .UseLowerCaseNamingConvention();
        }
    }
}
