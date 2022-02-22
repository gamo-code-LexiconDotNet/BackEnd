using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.ViewModels
{
  public class CountryCreateViewModel : IValidatableObject
  {
    public CountryCreateViewModel() { }

    [StringLength(48)]
    public string Name { get; set; }

    public int Id { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (string.IsNullOrWhiteSpace(Name) && Id < 1)
        yield return new ValidationResult(
          "Country must have a name",
          new[] { nameof(Name) });

      if (string.IsNullOrWhiteSpace(Name) && Id > 0)
        yield return new ValidationResult(
          "To edit a country name input a new name and choose the old name",
          new[] { nameof(Name) });
    }
  }
}
