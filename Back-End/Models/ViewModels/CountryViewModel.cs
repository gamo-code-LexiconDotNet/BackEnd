using Back_End.Models.Entities;
using System.Collections.Generic;

namespace Back_End.Models.ViewModels
{
  public class CountryViewModel
  {
    public CountryViewModel() { }

    public IEnumerable<Country> Countries { get; set; }

    public CountryCreateViewModel countryCreateViewModel;
  }
}
