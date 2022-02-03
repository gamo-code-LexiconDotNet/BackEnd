using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back_End.Controllers
{
  public class AjaxController : Controller
  {
    private readonly IPersonRepository personRepository;

    public AjaxController(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult People()
    {
      return PartialView("_PeoplePartialView", personRepository.All());
    }

    [HttpPost]
    public IActionResult Details(int id)
    {
      Person person = personRepository.GetById(id);

      if (person == null)
        return NotFound();

      return PartialView("_PersonPartialView", person);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      if (personRepository.Delete(id))
        return Ok();

      return NotFound();
    }
  }
}
