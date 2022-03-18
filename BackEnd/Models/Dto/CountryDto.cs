using BackEnd.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Dto
{
  public class CountryDto
  {
    private CountryDto() { }

    public static CountryDto Create(Country country)
    {
      if (country == null)
        return null;

      return new CountryDto
      {
        Id = country.Id,
        Name = country.Name,
        Cities = country.Cities.Select(city => CityDto.Create(city))
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("countries")]
    public IEnumerable<CityDto> Cities { get; set; }
  }
}
