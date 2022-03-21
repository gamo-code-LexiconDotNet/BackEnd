using BackEnd.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackEnd.Models.Dto
{
  public class PersonCreateDto
  {
    public Person ToEntity()
    {
      return new Person
      {
        Name = Name,
        PhoneNumber = PhoneNumber,
        CityId = CityId,
        PeopleLanguages = new List<PersonLanguage> {
          new PersonLanguage {
            LanguageId = LanguageId
          }}
      };
    }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("phonenumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("languageid")]
    public int LanguageId { get; set; }

    [JsonProperty("cityid")]
    public int CityId { get; set; }
  }
}
