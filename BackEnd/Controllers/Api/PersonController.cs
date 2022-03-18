using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class PersonController : ControllerBase
  {
    private readonly IPersonService personService;

    public PersonController(IPersonService personService)
    {
      this.personService = personService;
    }

    [HttpGet]
    public ActionResult<string> AllPersons()
    {
      var persons = personService.AllPersons();

      if (persons == null)
        return NotFound();

      return Ok(persons);
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetPerson(int id)
    {
      var person = personService.GetPerson(id);

      if (person == null)
        return NotFound();

      return Ok(person);
    }
  }
}
