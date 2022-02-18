using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.Entities
{
  public class Language
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(48)]
    public string Name { get; set; }

    public ICollection<PersonLanguage> PeopleLanguages { get; set; }
  }
}
