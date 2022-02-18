using Back_End.Models.Entities;
using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using static Back_End.Models.Services.PersonSessionService;

namespace Back_End.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonService personService;
    private readonly ICityService cityService;
    private readonly ICountryService countryService;
    private readonly ILanguageService languageService;

    public PersonController(IPersonService personService,
      ICityService cityService,
      ICountryService countryService,
      ILanguageService languageService)
    {
      this.personService = personService;
      this.cityService = cityService;
      this.countryService = countryService;
      this.languageService = languageService;
      CaseSensitiveInSession = false;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new PersonViewModel
      {
        People = personService.SearchAndOrder(null, false, null),
        NameSortParam = "name_desc",
        CitySortParam = "city_desc",
        CountrySortParam = "coutry_desc",
        CityList = CityList,
        CountryList = CountryList,
        LanguageList = LanguageList,
        NameList = PersonList,
      });
    }

    [HttpPost]
    public IActionResult Index(PersonViewModel personViewModel)
    {
      if (personViewModel.NameSortParam != null)
      {
        SortOrderInSesson = personViewModel.NameSortParam;
        NameSortParamInSession = SortOrderInSesson == "name" ? "name_desc" : "name";
      }
      else if (personViewModel.CitySortParam != null)
      {
        SortOrderInSesson = personViewModel.CitySortParam;
        CitySortParamInSession = SortOrderInSesson == "city" ? "city_desc" : "city";
      }
      else if (personViewModel.CountrySortParam != null)
      {
        SortOrderInSesson = personViewModel.CountrySortParam;
        CountrySortParamInSession = SortOrderInSesson == "country" ? "country_desc" : "country";
      }
      else
        SortOrderInSesson = "";

      // need to reset model state values or the old values will be passed through model binding
      ModelState.Remove("NameSortParam");
      ModelState.Remove("CitySortParam");
      ModelState.Remove("CountrySortParam");

      SearchTermInSession = personViewModel.SearchTerm ?? "";
      CaseSensitiveInSession = personViewModel.CaseSensitive;

      return View(new PersonViewModel
      {
        People = personService.SearchAndOrder(
          SearchTermInSession,
          CaseSensitiveInSession,
          SortOrderInSesson),
        SearchTerm = SearchTermInSession,
        CaseSensitive = CaseSensitiveInSession,
        NameSortParam = NameSortParamInSession,
        CitySortParam = CitySortParamInSession,
        CountrySortParam = CountrySortParamInSession,
        CityList = CityList,
        CountryList = CountryList,
        NameList = PersonList,
      });
    }

    [HttpPost]
    public IActionResult Create(PersonCreateViewModel personCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        personService.Add(personCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new PersonViewModel
      {
        People = personService.SearchAndOrder(
          SearchTermInSession,
          CaseSensitiveInSession,
          SortOrderInSesson),
        SearchTerm = SearchTermInSession,
        CaseSensitive = CaseSensitiveInSession,
        NameSortParam = NameSortParamInSession,
        CitySortParam = CitySortParamInSession,
        CountrySortParam = CountrySortParamInSession,
        CityList = CityList,
        CountryList = CountryList,
        NameList = PersonList,
        personCreateViewModel = personCreateViewModel
      });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (personService.Delete(id))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }

    [HttpGet]
    public IActionResult RemoveLanguage(int lid, int pid)
    {
      if (personService.RemoveLanguage(lid, pid))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }

    //
    // select lists
    //
    public List<SelectListItem> LanguageList
    {
      get
      {
        List<SelectListItem> list = new SelectList(languageService.All(), "Id", "Name").ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose language" });
        return list;
      }
    }

    public List<SelectListItem> PersonList
    {
      get
      {
        List<SelectListItem> list = new SelectList(personService.All(), "Id", "Name").ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose person" });
        return list;
      }
    }

    public List<SelectListItem> CityList
    {
      get
      {
        List<SelectListItem> list = new SelectList(cityService.All(), "Id", "Name").ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose city" });
        return list;
      }
    }
    public List<SelectListItem> CountryList
    {
      get
      {
        List<SelectListItem> list = new SelectList(countryService.All(), "Id", "Name").ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose country" });
        return list;
      }
    }
  }
}
