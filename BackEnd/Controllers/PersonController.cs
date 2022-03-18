using BackEnd.Models.Services;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BackEnd.Models.Services.PersonSessionService;

namespace BackEnd.Controllers
{
  [Authorize]
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
        CityList = cityService.CityList,
        CountryList = countryService.CountryList,
        LanguageList = languageService.LanguageList,
        PersonList = personService.PersonList
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
        SortOrderInSesson = "name";

      // need to reset model state values or the old values will be passed through with model binding
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
        CityList = cityService.CityList,
        CountryList = countryService.CountryList,
        LanguageList = languageService.LanguageList,
        PersonList = personService.PersonList
      });
    }

    [HttpPost]
    public IActionResult Create(PersonCreateViewModel personCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        // model data injection protection
        if(!User.IsInRole("Admin"))
        {
          personCreateViewModel.CityName = "";
          personCreateViewModel.CountryName = "";
          personCreateViewModel.CountryId = 0;
          personCreateViewModel.LanguageName = "";
        }

        personService.AddAndUpdate(personCreateViewModel);
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
        CityList = cityService.CityList,
        CountryList = countryService.CountryList,
        LanguageList = languageService.LanguageList,
        PersonList = personService.PersonList,
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
  }
}
