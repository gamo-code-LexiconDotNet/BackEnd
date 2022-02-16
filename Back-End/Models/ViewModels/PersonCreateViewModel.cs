using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.ViewModels
{
  public class PersonCreateViewModel
  {
    public PersonCreateViewModel() { }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(48)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [StringLength(24)]
    [RegularExpression(@"(\+\d{2})?[ \-]?(\(\d\))?[ \-]?[0-9\- ]*", ErrorMessage = "Must be a valid phone number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(48)]
    public string City { get; set; }
  }
}
