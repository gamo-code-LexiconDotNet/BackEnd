using Back_End.Models.Entities;
using Back_End.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back_End.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AjaxController : Controller
  {
    private readonly IPersonService personService;

    public AjaxController(IPersonService personService)
    {
      this.personService = personService;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public IActionResult People()
    {
      return PartialView("_PeoplePartialView", personService.All());
    }

    [HttpPost]
    public IActionResult Details(int id)
    {
      Person person = personService.GetById(id);

      if (person == null)
        return NotFound();

      return PartialView("_PersonPartialView", person);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      if (personService.Delete(id))
        return Ok();

      return NotFound();
    }
  }
}
