using Back_End.Models.Entities;
using System.Collections.Generic;

namespace Back_End.Models.Repositories
{
  public interface ICityRepository
  {
    public City Create(City city);
    public IEnumerable<City> Read();
    public City Read(int id);
    public City Update(City city);
    public bool Delete(int id);
  }
}
