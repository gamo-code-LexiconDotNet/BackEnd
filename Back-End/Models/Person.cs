using System.ComponentModel.DataAnnotations;

namespace Back_End.Models
{
  public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
  }
}
