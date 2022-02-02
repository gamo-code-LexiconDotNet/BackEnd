using Back_End.Models;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Back_End.Controllers
{
  public class PersonController : Controller
  {
    private readonly IPersonRepository personRepository;
    private static ModelStateDictionary ModelStateDictionary { get; set; } = null;

    public PersonController(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    [HttpGet]
    public IActionResult Index(string sortOrder)
    {
      if (PersonController.ModelStateDictionary != null)
        ModelState.Merge(PersonController.ModelStateDictionary);

      ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      ViewData["CitySortParm"] = sortOrder == "City" ? "city_desc" : "City";

      return View(new PersonViewModel
      {
        People = personRepository.OrderAllBy(sortOrder),
        SearchTerm = null,
        CaseSensitive = false
      });
      }

    [HttpPost]
    public IActionResult Create(CreatePersonViewModel createPersonViewModel)
    {
      if (ModelState.IsValid)
      {
        personRepository.Add(new Person
        {
          Name = createPersonViewModel.Name,
          PhoneNumber = createPersonViewModel.PhoneNumber,
          City = createPersonViewModel.City
        });

        ModelStateDictionary = null;
      }
      else
        ModelStateDictionary = ModelState;

      return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Search(string searchTerm, bool caseSensitive)
    { 
      return View("Index", new PersonViewModel
      {
        People = personRepository.Search(searchTerm, caseSensitive),
        SearchTerm = searchTerm,
        CaseSensitive = caseSensitive
      });
      }
  }
}
