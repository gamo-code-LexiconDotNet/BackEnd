using BackEnd.Models.Services;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  [Authorize(Roles = "Admin")]
  public class LanguageController : Controller
  {
    private readonly ILanguageService languageService;
    private readonly IPersonService personService;

    public LanguageController(
      ILanguageService languageService,
      IPersonService personService)
    {
      this.languageService = languageService;
      this.personService = personService;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new LanguageViewModel
      {
        Languages = languageService.All(),
        LanguageList = languageService.LanguageList,
        PersonList = personService.PersonList
      });
    }

    [HttpPost]
    public IActionResult Create(LanguageCreateViewModel languageCreateViewModel)
    {
      if (ModelState.IsValid)
      {
        languageService.Add(languageCreateViewModel);
        return RedirectToAction("Index");
      }

      return View("Index", new LanguageViewModel
      {
        Languages = languageService.All(),
        LanguageList = languageService.LanguageList,
        PersonList = personService.PersonList,
        languageCreateViewModel = languageCreateViewModel
      });
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      if (languageService.Delete(id))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }

    [HttpGet]
    public IActionResult RemovePerson(int lid, int pid)
    {
      if (languageService.RemovePerson(lid, pid))
        return RedirectToAction("Index");

      return RedirectToAction("Index"); // fix on fail
    }
  }
}
