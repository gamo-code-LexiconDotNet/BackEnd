using BackEnd.Models.Data;
using BackEnd.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Repositories
{
  public class CountryRepository : ICountryRepository
  {
    private readonly AppDbContext appDbContext;

    public CountryRepository(AppDbContext appDbContext)
    {
      this.appDbContext = appDbContext;
    }

    public Country Create(Country country)
    {
      var newCountry= appDbContext.Countries.Add(new Country
      {
        Name = country.Name
      });

      appDbContext.SaveChanges();

      return newCountry.Entity;
    }

    public IEnumerable<Country> Read()
    {
      return appDbContext.Countries
        .Include(c => c.Cities);
    }

    public Country Read(int id)
    {
      return appDbContext.Countries
        .Include(c => c.Cities)
        .FirstOrDefault(c => c.Id == id);
    }

    public Country Update(Country country)
    {
      var entry = appDbContext.Entry(country);

      entry.State = EntityState.Modified;
      appDbContext.SaveChanges();

      return entry.Entity;
    }

    public bool Delete(int id)
    {
      var country = appDbContext.Countries.Find(id);

      if (country == null)
        return false;

      appDbContext.Countries.Remove(country);
      appDbContext.SaveChanges();

      return true;
    }
  }
}
