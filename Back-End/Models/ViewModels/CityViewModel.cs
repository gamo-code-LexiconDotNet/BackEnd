using Back_End.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.ViewModels
{
  public class CityViewModel
  {
    public CityViewModel() { }

    public IEnumerable<City> Cities { get; set; }

    public SelectList Countries { get; set; }

    public CityCreateViewModel cityCreateViewModel;
  }
}
