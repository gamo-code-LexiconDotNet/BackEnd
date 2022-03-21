using BackEnd.Models.Dto;
using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

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

      return Ok(JsonConvert.SerializeObject(persons));
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetPerson(int id)
    {
      var person = personService.GetPerson(id);

      if (person == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(person));
    }

    [HttpGet("list")]
    public ActionResult<string> PersonList()
    {
      var personList = personService.PersonList();

      if (personList == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(personList));
    }

    [HttpPost]
    public ActionResult<string> AddPerson(object createPerson)
    {
      var createPersonDto = JsonConvert.DeserializeObject<PersonCreateDto>(createPerson.ToString());

      var newPerson = personService.AddPerson(createPersonDto);

      if (newPerson == null)
        return NotFound();
      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult<string> RemovePerson(int id)
    {
      var success = personService.RemovePerson(id);

      if (!success)
        return NotFound();

      return Ok();
    }
  }
}
