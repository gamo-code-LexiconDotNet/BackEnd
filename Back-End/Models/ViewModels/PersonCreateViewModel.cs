using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Back_End.Models.ViewModels
{
  public class PersonCreateViewModel : IValidatableObject
  {
    public PersonCreateViewModel() { }

    [StringLength(48)]
    public string Name { get; set; }

    public int Id { get; set; }

    [StringLength(24)]
    [RegularExpression(@"(\+\d{2})?[ \-]?(\(\d\))?[ \-]?[0-9\- ]*", ErrorMessage = "Must be a valid phone number")]
    public string PhoneNumber { get; set; }

    [StringLength(48)]
    public string CityName { get; set; }

    public int CityId { get; set; }

    [StringLength(48)]
    public string CountryName { get; set; }

    public int CountryId { get; set; }

    [StringLength(48)]
    public string LanguageName { get; set; }

    public int LanguageId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

      bool hasName = !string.IsNullOrEmpty(Name);
      bool hasId = Id > 0;
      bool hasPhoneNumber = !string.IsNullOrEmpty(PhoneNumber);
      bool hasCityName = !string.IsNullOrEmpty(CityName);
      bool hasCityId = CityId > 0;
      bool hasCountryName = !string.IsNullOrEmpty(CountryName);
      bool hasCountryId = CountryId > 0;
      bool hasLanguageName = !string.IsNullOrEmpty(LanguageName);
      bool hasLanguageId = LanguageId > 0;

      // no user
      if (
        !hasName
        && !hasId
        )
        yield return new ValidationResult(
          "Input a new user or choose a user in the list",
          new[] { nameof(Name) });

      // new person need phone number
      if (
        hasName
        && !hasPhoneNumber
        )
        yield return new ValidationResult(
          "A new person needs a phone number.",
          new[] { nameof(PhoneNumber) });

      // new person needs city
      if (
        hasName
        && !hasCityName
        && !hasCityId
        )
        yield return new ValidationResult(
          "A new person needs a city.",
          new[] { nameof(CityName) });

      // update person needs input
      if (
        !hasName
        && hasId
        && !hasPhoneNumber
        && !hasCityName
        && !hasCityId
        && !hasCountryName
        && !hasCountryId
        && !hasLanguageName
        && !hasLanguageId
        )
        yield return new ValidationResult(
          "Select or input more data to update person.",
          new[] { nameof(Name) });

      // phone number needs person
      if (
        !hasName
        && !hasId
        && hasPhoneNumber
        )
        yield return new ValidationResult(
          "Input or choose a person for the phone number.",
          new[] { nameof(Name) });

      // new city needs a country
      if (
        hasCityName
        && !hasCountryName
        && !hasCountryId
        )
        yield return new ValidationResult(
          "A new city needs a country",
          new[] { nameof(CountryName) });

      // cannot rename city from person view
      if (hasCityName
        && hasCityId
        )
        yield return new ValidationResult(
          "Input new city or choose a city in the list.",
          new[] { nameof(CityName) });

      // cannot rename country from person view
      if (hasCountryName
        && hasCountryId
        )
        yield return new ValidationResult(
          "Input new country or choose a country in the list.",
          new[] { nameof(CountryName) });

      // cannot rename language from person view
      if (hasLanguageName
        && hasLanguageId
        )
        yield return new ValidationResult(
          "Input new language or choose a language in the list.",
          new[] { nameof(LanguageName) });

      // country needs a city
      if (
        !hasCityName
        && !hasCityId
        && (hasCountryName || hasCountryId)
        )
        yield return new ValidationResult(
          "Input a new city or choose a city in the list",
          new[] { nameof(CityName) });

      /*
      if (
        hasName
        && hasId
        && hasPhoneNumber
        && hasCityName
        && hasCityId
        && hasCountryName
        && hasCountryId
        && hasLanguageName
        && hasLanguageId
        )
        yield return new ValidationResult(
          "",
          new[] { nameof() });
      */
    }
  }
}
