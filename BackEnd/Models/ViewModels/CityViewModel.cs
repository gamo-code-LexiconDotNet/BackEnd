using BackEnd.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.ViewModels
{
  public class CityViewModel
  {
    public CityViewModel() { }

    public IEnumerable<City> Cities { get; set; }

    public IEnumerable<SelectListItem> CountryList { get; set; }

    public IEnumerable<SelectListItem> CityList { get; set; }

    public CityCreateViewModel cityCreateViewModel;
  }
}
