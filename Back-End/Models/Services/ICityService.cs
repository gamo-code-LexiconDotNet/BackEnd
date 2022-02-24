using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface ICityService
  {
    List<SelectListItem> CityList { get; }
    City AddAndUpdate(CityCreateViewModel cityCreateViewModel);
    IEnumerable<City> All();
    bool Delete(int id);
  }
}
