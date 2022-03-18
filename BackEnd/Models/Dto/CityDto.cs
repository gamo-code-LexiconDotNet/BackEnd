using BackEnd.Models.Entities;
using Newtonsoft.Json;

namespace BackEnd.Models.Dto
{
  public class CityDto
  {
    private CityDto() { }

    public static CityDto Create(City city = null)
    {
      if (city == null)
        return null;

      return new CityDto
      {
        Id = city.Id,
        Name = city.Name,
        CountryId = city.Country.Id,
        Country = city.Country.Name
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("countryid")]
    public int CountryId { get; set; }

    [JsonProperty("countryname")]
    public string Country { get; set; }
  }
}
