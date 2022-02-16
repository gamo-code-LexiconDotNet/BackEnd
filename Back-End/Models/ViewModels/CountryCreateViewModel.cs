using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.ViewModels
{
  public class CountryCreateViewModel
  {
    public CountryCreateViewModel() { }

    [Required(ErrorMessage = "Country name is required.")]
    [StringLength(48)]
    public string Name { get; set; }
  }
}
