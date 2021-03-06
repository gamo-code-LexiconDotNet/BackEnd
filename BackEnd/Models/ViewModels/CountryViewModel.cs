using BackEnd.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.ViewModels
{
  public class CountryViewModel
  {
    public CountryViewModel() { }

    public List<SelectListItem> CountryList { get; set; }

    public List<SelectListItem> CityList { get; set; }

    public IEnumerable<Country> Countries { get; set; }

    public CountryCreateViewModel countryCreateViewModel;
  }
}
