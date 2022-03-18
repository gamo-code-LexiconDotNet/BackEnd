using BackEnd.Models.Dto;
using BackEnd.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services.Api
{
  public class CountryService : ICountryService
  {
    private readonly ICountryRepository countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
      this.countryRepository = countryRepository;
    }

    public IEnumerable<CountryDto> AllCountries()
    {
      var countries = countryRepository.Read();

      if (countries == null)
        return null;

      return countries.Select(country => CountryDto.Create(country));
    }

    public CountryDto GetCountry(int id)
    {
      return CountryDto.Create(countryRepository.Read(id));
    }
  }
}
