using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.Entities
{
  public class City
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(48)]
    public string Name { get; set; }

    public int CountryId { get; set; }
    public virtual Country Country { get; set; }

    public ICollection<Person> People { get; set; }
  }
}
