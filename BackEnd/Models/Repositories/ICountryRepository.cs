using BackEnd.Models.Entities;
using System.Collections.Generic;

namespace BackEnd.Models.Repositories
{
  public interface ICountryRepository
  {
    public Country Create(Country country);
    public IEnumerable<Country> Read();
    public Country Read(int id);
    public Country Update(Country country);
    public bool Delete(int id);
  }
}
