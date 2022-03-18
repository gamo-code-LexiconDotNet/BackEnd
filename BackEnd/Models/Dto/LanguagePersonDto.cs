using BackEnd.Models.Entities;
using Newtonsoft.Json;

namespace BackEnd.Models.Dto
{
  public class LanguagePersonDto
  {
    private LanguagePersonDto() { }

    public static LanguagePersonDto Create(Person person)
    {
      if (person == null)
        return null;

      return new LanguagePersonDto
      {
        Id = person.Id,
        Name = person.Name
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
