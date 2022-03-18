using BackEnd.Models.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace BackEnd.Models.Dto
{
  public class PersonDto
  {
    private PersonDto() { }

    public static PersonDto Create(Person person)
    {
      if (person == null)
        return null;

      return new PersonDto
      {
        Id = person.Id,
        Name = person.Name,
        PhoneNumber = person.PhoneNumber,
        City = CityDto.Create(person.City),
        Languages = person.PeopleLanguages.Select(pl => PersonLanguageDto.Create(pl.Langauge)).ToArray()
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("phonenumber")]
    public string PhoneNumber { get; set; }
    [JsonProperty("city")]
    public CityDto City { get; set; }
    [JsonProperty("languages")]
    public PersonLanguageDto[] Languages { get; set; }
  }
}
