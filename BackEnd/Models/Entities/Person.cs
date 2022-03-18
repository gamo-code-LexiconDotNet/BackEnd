using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Entities
{
  public class Person
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(48)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(24)]
    public string PhoneNumber { get; set; }

    public int CityId { get; set; }
    public virtual City City { get; set; }

    public ICollection<PersonLanguage> PeopleLanguages { get; set; }
  }
}
