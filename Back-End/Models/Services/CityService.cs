using Back_End.Models.Entities;
using Back_End.Models.Repositories;
using Back_End.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Services
{
  public class CityService : ICityService
  {
    private readonly ICityRepository cityRepository;

    public CityService(ICityRepository cityRepository)
    {
      this.cityRepository = cityRepository;
    }

    public City Add(CityCreateViewModel cityCreateViewModel)
    {
      if (cityCreateViewModel == null
        || string.IsNullOrWhiteSpace(cityCreateViewModel.Name))
        return null;

      City newCity = new City
      {
        Name = cityCreateViewModel.Name
      };

      if (!string.IsNullOrWhiteSpace(cityCreateViewModel.CountryName))
      {
        newCity.Country = new Country
        {
          Name = cityCreateViewModel.CountryName
        };
      }
      else if (cityCreateViewModel.CountryId > 0)
        newCity.CountryId = cityCreateViewModel.CountryId;
      else
        return null;

      cityRepository.Create(newCity);

      return newCity;
    }

    public IEnumerable<City> All()
    {
      return cityRepository.Read().OrderBy(c => c.Name);
    }

    public bool Delete(int id)
    {
      return cityRepository.Delete(id);
    }

    public City GetById(int id)
    {
      return cityRepository.Read(id);
    }

    public bool CountryHasName(string name)
    {
      return cityRepository.Read().Where(c => c.Country.Name == name).Any();
    }

    public bool CountryHasId(int id)
    {
      return cityRepository.Read().Where(c => c.Country.Id == id).Any();
    }
  }
}
