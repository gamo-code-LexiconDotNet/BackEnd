using Back_End.Models;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Back_End.Models.PersonSession;

namespace Back_End.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonRepository personRepository;

    public PersonController(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new PersonViewModel
      {
        People = personRepository.SearchAndOrder(null, false, null),
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
        People = personRepository.SearchAndOrder(
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
        personRepository.Add(new Person
        {
          Name = personCreateViewModel.Name,
          PhoneNumber = personCreateViewModel.PhoneNumber,
          City = personCreateViewModel.City
        });

        return RedirectToAction("Index");
      }

      return View("Index", new PersonViewModel
      {
        People = personRepository.SearchAndOrder(
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
