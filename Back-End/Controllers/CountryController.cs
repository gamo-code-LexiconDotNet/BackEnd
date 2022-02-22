using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Controllers
{
  public class CountryController : Controller
  {
    private readonly ICountryService countryService;

    public CountryController(ICountryService countryService)
    {
      this.countryService = countryService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new CountryViewModel
      {
        Countries = countryService.All(),
        CountryList = CountryList
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
        CountryList = CountryList
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

    public List<SelectListItem> CountryList
    {
      get
      {
        List<SelectListItem> pl = new SelectList(countryService.All(), "Id", "Name").ToList();
        pl.Insert(0, new SelectListItem { Value = "0", Text = "Choose Country" });
        return pl;
      }
    }
  }
}
