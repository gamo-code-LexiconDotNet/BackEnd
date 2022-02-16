using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface ICityService
  {
    City Add(CityCreateViewModel cityCreateViewModel);
    IEnumerable<City> All();
    City GetById(int id);
    bool Delete(int id);
    bool CountryHasId(int id);
    bool CountryHasName(string name);
  }
}
