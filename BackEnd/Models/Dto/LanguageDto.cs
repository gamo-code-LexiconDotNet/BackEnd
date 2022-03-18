using BackEnd.Models.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace BackEnd.Models.Dto
{
  public class LanguageDto
  {
    private LanguageDto() { }

    public static LanguageDto Create(Language language)
    {
      if (language == null)
        return null;

      return new LanguageDto
      {
        Id = language.Id,
        Name = language.Name,
        Persons = language.PeopleLanguages.Select(pl => LanguagePersonDto.Create(pl.Person)).ToArray()
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("persons")]
    public LanguagePersonDto[] Persons { get; set; }
  }
}
