using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Entities
{
  public class Country
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(48)]
    public string Name { get; set; }

    public ICollection<City> Cities { get; set; }
  }
}
