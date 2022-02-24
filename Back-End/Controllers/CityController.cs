using Back_End.Models.Entities;
using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Back_End.Controllers
{
  [Authorize(Roles = "Admin")]
  public class CityController : Controller
  {
    private readonly ICityService cityService;
    private readonly ICountryService countryService;

    public CityController(ICityService cityService,
      ICountryService countryService)
    {
      this.cityService = cityService;
      this.countryService = countryService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new CityViewModel
      {
        Cities = cityService.All(),
        CountryList = countryService.CountryList,
        CityList = cityService.CityList
      });
    }

    [HttpPost]
    public IActionResult Create(CityCreateViewModel cityCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        cityService.AddAndUpdate(cityCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new CityViewModel
      {
        Cities = cityService.All(),
        CountryList = countryService.CountryList,
        CityList = cityService.CityList,
        cityCreateViewModel = cityCreateViewModel
      });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (cityService.Delete(id))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }
  }
}
