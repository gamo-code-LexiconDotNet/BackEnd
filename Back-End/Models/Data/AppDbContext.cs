using Back_End.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Models.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }

    public DbSet<Person> People { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Person>()
        .HasOne<City>(p => p.City)
        .WithMany(c => c.People)
        .HasForeignKey(p => p.CityId);

      modelBuilder.Entity<City>()
        .HasOne<Country>(ci => ci.Country)
        .WithMany(co => co.Cities)
        .HasForeignKey(ci => ci.CountryId);

      modelBuilder.Entity<Country>().HasData(
        new Country
        {
          Id = 1,
          Name = "Holland"
        },
        new Country
        {
          Id = 2,
          Name = "Germany"
        },
        new Country
        {
          Id = 3,
          Name = "Denmark"
        },
        new Country
        {
          Id = 4,
          Name = "Ireland"
        }
      );

      modelBuilder.Entity<City>().HasData(
        new City
        {
          Id = 1,
          CountryId = 1,
          Name = "Amsterdam"
        },
        new City
        {
          Id = 2,
          CountryId = 2,
          Name = "Berlin"
        },
        new City
        {
          Id = 3,
          CountryId = 3,
          Name = "Copenhagen"
        },
        new City
        {
          Id = 4,
          CountryId = 4,
          Name = "Dublin"
        }
      );


      modelBuilder.Entity<Person>().HasData(
        new Person
        {
          Id = 1,
          Name = "Alice",
          PhoneNumber = "1234567890",
          CityId = 1
        },
        new Person
        {
          Id = 2,
          Name = "Bob",
          PhoneNumber = "2345679801",
          CityId = 2
        },
        new Person
        {
          Id = 3,
          Name = "Carol",
          PhoneNumber = "3456789012",
          CityId = 3
        },
        new Person
        {
          Id = 4,
          Name = "Dan",
          PhoneNumber = "4567890123",
          CityId = 4
        }
      );
    }
  }
}
