using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back_End.Models.Entities
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
  }
}
