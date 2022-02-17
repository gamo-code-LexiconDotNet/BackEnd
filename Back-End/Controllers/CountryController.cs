using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
      });
    }

    [HttpPost]
    public IActionResult Create(CountryCreateViewModel countryCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        countryService.Add(countryCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new CountryViewModel
      {
        Countries = countryService.All(),
        countryCreateViewModel = countryCreateViewModel
      });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (countryService.Delete(id))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }
  }
}
