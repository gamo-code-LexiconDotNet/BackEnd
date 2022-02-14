using Back_End.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Models.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options) { }

    public DbSet<Person> Person { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Person>().HasData(
        new Person
        {
          Id = 1,
          Name = "Alice",
          PhoneNumber = "1234567890",
          City = "Amsterdam"
        },
        new Person
        {
          Id = 2,
          Name = "Bob",
          PhoneNumber = "2345679801",
          City = "Berlin"
        },
        new Person
        {
          Id = 3,
          Name = "Carol",
          PhoneNumber = "3456789012",
          City = "Copenhagen"
        },
        new Person
        {
          Id = 4,
          Name = "Dan",
          PhoneNumber = "4567890123",
          City = "Dublin"
        }
      );
    }
  }
}
