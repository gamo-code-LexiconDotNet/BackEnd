using BackEnd.Models.Entities;
using Newtonsoft.Json;

namespace BackEnd.Models.Dto
{
  public class PersonLanguageDto
  {
    private PersonLanguageDto() { }

    public static PersonLanguageDto Create(Language language)
    {
      if (language == null)
        return null;

      return new PersonLanguageDto
      {
        Id = language.Id,
        Name = language.Name
      };
    }

    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
