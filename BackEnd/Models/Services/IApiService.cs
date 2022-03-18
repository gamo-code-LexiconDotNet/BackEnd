using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services
{
  public interface IApiService
  {
    public IEnumerable<PersonDto> AllPersons();
    public PersonDto GetPerson(int id);
    public IEnumerable<CityDto> AllCities();
    public CityDto GetCity(int id);
    public IEnumerable<CountryDto> AllCountries();
    public CountryDto GetCountry(int id);
    public IEnumerable<LanguageDto> AllLanguages();
    public LanguageDto GetLanguage(int id);
  }
}
