using BackEnd.Models.Dto;
using BackEnd.Models.Entities;
using BackEnd.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services.Api
{
  public class CityService : ICityService
  {
    private readonly ICityRepository cityRepository;

    public CityService(ICityRepository cityRepository)
    {
      this.cityRepository = cityRepository;
    }

    public IEnumerable<CityDto> AllCities()
    {
      var cities = cityRepository.Read();

      if (cities == null)
        return null;

      return cities.Select(city => CityDto.Create(city));
    }

    public CityDto GetCity(int id)
    {
      return CityDto.Create(cityRepository.Read(id));
    }

    public IEnumerable<object> CitiesList()
    {
      var cities = cityRepository.Read();

      if (cities == null)
        return null;

      return from city in cities
             orderby city.Name
             select new { id = city.Id, name = city.Name };
    }
  }
}
