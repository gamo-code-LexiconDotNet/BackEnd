using BackEnd.Models.Entities;
using BackEnd.Models.Repositories;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services
{
  public class CityService : ICityService
  {
    private readonly ICityRepository cityRepository;

    public CityService(ICityRepository cityRepository)
    {
      this.cityRepository = cityRepository;
    }

    public City AddAndUpdate(CityCreateViewModel vm)
    {
      bool hasName = !string.IsNullOrEmpty(vm.Name);
      bool hasId = vm.Id > 0;
      bool hasCountryId = vm.CountryId > 0;

      if (hasName && hasId && hasCountryId)
        return UpdateCity(vm);

      if (hasName && hasCountryId)
        return CreateCity(vm);

      if (hasId && (hasName || hasCountryId))
        return UpdateCity(vm);

      return null;
    }

    public City CreateCity(CityCreateViewModel vm)
    {
      City city = new City();
      city.Name = vm.Name;

      if (vm.CountryId > 0)
        city.CountryId = vm.CountryId;

      return cityRepository.Create(city);
    }

    public City UpdateCity(CityCreateViewModel vm)
    {
      City city = cityRepository.Read(vm.Id);

      if (city == null)
        return null;

      if (!string.IsNullOrEmpty(vm.Name))
        city.Name = vm.Name;

      if (vm.CountryId > 0)
        city.CountryId = vm.CountryId;

      return cityRepository.Update(city);
    }

    public IEnumerable<City> All()
    {
      return cityRepository.Read().OrderBy(c => c.Name);
    }

    public bool Delete(int id)
    {
      return cityRepository.Delete(id);
    }

    public List<SelectListItem> CityList
    {
      get
      {
        List<SelectListItem> list = new SelectList(All(), "Id", "Name").OrderBy(c => c.Text).ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose city" });
        return list;
      }
    }
  }
}
