using BackEnd.Models.Entities;
using System.Collections.Generic;

namespace BackEnd.Models.Repositories
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
