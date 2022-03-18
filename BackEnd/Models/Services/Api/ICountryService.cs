using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services.Api
{
  public interface ICountryService
  {
    public IEnumerable<CountryDto> AllCountries();
    public CountryDto GetCountry(int id);
  }
}
