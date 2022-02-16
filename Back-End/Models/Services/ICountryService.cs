using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface ICountryService
  {
    Country Add(CountryCreateViewModel countryCreateViewModel);
    IEnumerable<Country> All();
    Country GetById(int id);
    bool Delete(int id);

  }
}
