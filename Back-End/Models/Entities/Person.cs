using System.ComponentModel.DataAnnotations;

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

    [Required]
    [MaxLength(48)]
    public string City { get; set; }
  }
}
