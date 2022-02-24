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
      bool hasName = !string.IsNullOrWhiteSpace(Name);
      bool hasId = Id > 0;

      if (!hasName && !hasId)
        yield return new ValidationResult(
          "Input a new country name or choose a country name in the list",
          new[] { nameof(Name) });

      if (!hasName && hasId)
        yield return new ValidationResult(
          "To edit a country name input a new name and choose the old name",
          new[] { nameof(Name) });
    }
  }
}
