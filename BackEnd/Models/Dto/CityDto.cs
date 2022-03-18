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
        Country = city.Country.Name,
        CountryId = city.Country.Id
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("country_id")]
    public int CountryId { get; set; }
    [JsonProperty("country_name")]
    public string Country { get; set; }
  }
}
