using Back_End.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ApiController : ControllerBase
  {
    private readonly IPersonRepository personRepository;

    public ApiController(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    [HttpGet]
    public ActionResult<string> Test()
    {
      var testData = "";
      
      foreach (var person in personRepository.Read())
      {
        testData += "" + person.Name;
      }

      return Ok(testData);
    }
  }
}
