using Back_End.Models.Entities;
using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Back_End.Models.Services.PersonSessionService;

namespace Back_End.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonService personService;

    public PersonController(IPersonService personService)
    {
      this.personService = personService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new PersonViewModel
      {
        People = personService.SearchAndOrder(null, false, null),
        NameSortParam = "name_desc",
        CitySortParam = "city_desc"
      });
    }

    [HttpPost]
    public IActionResult Index(PersonViewModel personViewModel)
    {
      if (personViewModel.NameSortParam != null)
        SortOrderInSesson = personViewModel.NameSortParam;
      else if (personViewModel.CitySortParam != null)
        SortOrderInSesson = personViewModel.CitySortParam;
      else
        SortOrderInSesson = "";

      NameSortParamInSession = string.IsNullOrEmpty(SortOrderInSesson) ? "name_desc" : "";
      CitySortParamInSession = SortOrderInSesson == "city" ? "city_desc" : "city";

      // need to reset model state values or the old values will be passed through model binding
      ModelState.Remove("NameSortParam");
      ModelState.Remove("CitySortParam");

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
      });
    }

    [HttpPost]
    public IActionResult Create(PersonCreateViewModel personCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        //personService.Add(new Person
        //{
        //  Name = personCreateViewModel.Name,
        //  PhoneNumber = personCreateViewModel.PhoneNumber,
        //  City = personCreateViewModel.City
        //});

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
        personCreateViewModel = personCreateViewModel
      });
    }
  }
}
