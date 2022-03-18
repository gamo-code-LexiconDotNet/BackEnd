using BackEnd.Models.Entities;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.Services
{
  public interface ICountryService
  {
    List<SelectListItem> CountryList { get; }
    Country Add(CountryCreateViewModel countryCreateViewModel);
    IEnumerable<Country> All();
    Country GetById(int id);
    bool Delete(int id);
    Country AddOrUpdate(CountryCreateViewModel Vm);
    Country Update(CountryCreateViewModel Vm);
    bool RemoveCity(int countryId, int cityId);
  }
}
