using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.ViewModels
{
  public class CityCreateViewModel : IValidatableObject
  {
    public CityCreateViewModel() { }

    [StringLength(48)]
    public string Name { get; set; }
    public int Id { get; set; }
    public int CountryId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      bool hasName = !string.IsNullOrEmpty(Name);
      bool hasId = Id > 0;
      bool hasCountryId = CountryId > 0;

      if (!hasName
        & !hasId
        & !hasCountryId)
        yield return new ValidationResult(
          "Create a new city, change city name or change country.",
          new[] { nameof(Name) });

      if (hasName
        & !hasId
        & !hasCountryId)
        yield return new ValidationResult(
          "A new city must have a country.",
          new[] { nameof(CountryId) });

      if (!hasName
        & hasId
        & !hasCountryId)
        yield return new ValidationResult(
          "Edit city name or change country.",
          new[] { nameof(Name), nameof(CountryId) });
    }
  }
}
