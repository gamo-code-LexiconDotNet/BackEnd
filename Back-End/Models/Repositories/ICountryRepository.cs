using Back_End.Models.Entities;
using System.Collections.Generic;

namespace Back_End.Models.Repositories
{
  public interface ICountryRepository
  {
    public Country Create(Country country);
    public IEnumerable<Country> Read();
    public Country Read(int id);
    public Country Update(Country country);
    public bool Delete(int id);
    //public bool HasId(int id);
    //public bool HasName(int id);
  }
}
