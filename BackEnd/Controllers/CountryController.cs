using BackEnd.Models.Services;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  [Authorize(Roles = "Admin")]
  public class CountryController : Controller
  {
    private readonly ICountryService countryService;
    private readonly ICityService cityService;

    public CountryController(ICountryService countryService,
      ICityService cityService)
    {
      this.countryService = countryService;
      this.cityService = cityService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new CountryViewModel
      {
        Countries = countryService.All(),
        CountryList = countryService.CountryList,
        CityList = cityService.CityList
      });
    }

    [HttpPost]
    public IActionResult CreateOrUpdate(CountryCreateViewModel countryCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        countryService.AddOrUpdate(countryCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new CountryViewModel
      {
        Countries = countryService.All(),
        countryCreateViewModel = countryCreateViewModel,
        CountryList = countryService.CountryList,
        CityList = cityService.CityList
      });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (countryService.Delete(id))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }

    [HttpGet]
    public IActionResult RemoveCity(int countryId, int cityId)
    {
      if (countryService.RemoveCity(countryId, cityId))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }
  }
}
