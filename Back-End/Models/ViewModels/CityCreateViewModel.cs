using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.ViewModels
{
  public class CityCreateViewModel
  {
    public CityCreateViewModel() { }

    [Required(ErrorMessage = "City name is required.")]
    [StringLength(48)]
    public string Name { get; set; }
    public string CountryName { get; set; }
    public int CountryId { get; set; }
  }
}
