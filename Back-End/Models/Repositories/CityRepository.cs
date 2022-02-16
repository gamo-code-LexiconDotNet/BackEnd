using Back_End.Models.Data;
using Back_End.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Repositories
{
  public class CityRepository : ICityRepository
  {
    private readonly AppDbContext appDbContext;

    public CityRepository(AppDbContext appDbContext)
    {
      this.appDbContext = appDbContext;
    }

    public City Create(City city)
    {
      var newCity = appDbContext.Cities.Add(city);

      appDbContext.SaveChanges();

      return newCity.Entity;
    }

    public IEnumerable<City> Read()
    {
      return appDbContext.Cities
        .Include(c => c.Country);
    }

    public City Read(int id)
    {
      return appDbContext.Cities.FirstOrDefault(c => c.Id == id);
    }

    public City Update(City city)
    {
      var entry = appDbContext.Entry(city);

      entry.State = EntityState.Modified;
      appDbContext.SaveChanges();

      return entry.Entity;
    }

    public bool Delete(int id)
    {
      var city = appDbContext.Cities.Find(id);

      if (city == null)
        return false;

      appDbContext.Cities.Remove(city);
      appDbContext.SaveChanges();

      return true;
    }

  }
}
