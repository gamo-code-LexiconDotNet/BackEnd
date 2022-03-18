using BackEnd.Models.Dto;
using BackEnd.Models.Entities;
using BackEnd.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services
{
  public class ApiService : IApiService
  {
    private readonly IPersonRepository personRepository;
    private readonly ICityRepository cityRepository;
    private readonly ICountryRepository countryRepository;
    private readonly ILanguageRepository languageRepository;

    public ApiService(IPersonRepository personRepository,
      ICityRepository cityRepository,
      ICountryRepository countryRepository,
      ILanguageRepository languageRepository)
    {
      this.personRepository = personRepository;
      this.cityRepository = cityRepository;
      this.countryRepository = countryRepository;
      this.languageRepository = languageRepository;
    }


    // --- Person ---
    public IEnumerable<PersonDto> AllPersons()
    {
      var persons = personRepository.Read();

      if (persons == null)
        return null;

      return persons.Select(
        person => PersonDto.Create(person));
    }

    public PersonDto GetPerson(int id)
    {
      return PersonDto.Create(personRepository.Read(id));
    }


    // --- City ---
    public IEnumerable<CityDto> AllCities()
    {
      var cities = cityRepository.Read();

      if (cities == null)
        return null;

      var citiesDto = cities.Select(city => CityDto.Create(city));

      return citiesDto;
    }

    public CityDto GetCity(int id)
    {
      var cityDto = CityDto.Create(cityRepository.Read(id));

      if (cityDto == null)
        return null;

      return cityDto;
    }

    // --- Country ---
    public IEnumerable<CountryDto> AllCountries()
    {
      var countries = countryRepository.Read();

      if (countries == null)
        return null;

      var countriesDto = countries.Select(country => CountryDto.Create(country));

      return countriesDto;
    }

    public CountryDto GetCountry(int id)
    {
      var cityDto = CountryDto.Create(countryRepository.Read(id));

      if (cityDto == null)
        return null;

      return cityDto;
    }

    // --- Language ---
    public IEnumerable<LanguageDto> AllLanguages()
    {
      var languages = languageRepository.Read();

      if (languages == null)
        return null;

      var languagesDto = languages.Select(language => LanguageDto.Create(language));

      return languagesDto;
    }

    public LanguageDto GetLanguage(int id)
    {
      var languageDto = LanguageDto.Create(languageRepository.Read(id));

      if (languageDto == null)
        return null;

      return languageDto;
    }
  }
}
