using BackEnd.Models.Entities;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.Services
{
  public interface ICityService
  {
    List<SelectListItem> CityList { get; }
    City AddAndUpdate(CityCreateViewModel cityCreateViewModel);
    IEnumerable<City> All();
    bool Delete(int id);
  }
}
