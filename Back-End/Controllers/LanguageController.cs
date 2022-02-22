using Back_End.Models.Services;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Controllers
{
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

    public List<SelectListItem> LanguageList
    {
      get 
      {
        List<SelectListItem> pl = new SelectList(languageService.All(), "Id", "Name").ToList();
        pl.Insert(0, new SelectListItem { Value = "0", Text = "Choose language" });
        return pl;
      }
    }

    public List<SelectListItem> PersonList
    {
      get
      {
        List<SelectListItem> pl = new SelectList(personService.All(), "Id", "Name").ToList();
        pl.Insert(0, new SelectListItem { Value = "0", Text = "Add person" });
        return pl;
      }
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(new LanguageViewModel
      {
        Languages = languageService.All(),
        LanguageList = LanguageList,
        PersonList = PersonList
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
        LanguageList = LanguageList,
        PersonList = PersonList,
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
