using BackEnd.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  [Route("old/[controller]")]
  [ApiController]
  public class ApiController : ControllerBase
  {
    private readonly IApiService apiService;

    public ApiController(IApiService apiService)
    {
      this.apiService = apiService;
    }


    // --- person ---
    [HttpGet("person")]
    public ActionResult<string> AllPersons()
    {
      var persons = apiService.AllPersons();

      if (persons == null)
        return NotFound();

      return Ok(persons);
    }

    [HttpGet("person/{id}")]
    public ActionResult<string> GetPerson(int id)
    {
      var person = apiService.GetPerson(id);

      if (person == null)
        return NotFound();

      return Ok(person);
    }


    // --- city ---
    [HttpGet("city")]
    public ActionResult<string> AllCities()
    {
      var cities = apiService.AllCities();

      return Ok(cities);
    }

    [HttpGet("city/{id}")]
    public ActionResult<string> GetCity(int id)
    {
      var city = apiService.GetCity(id);

      return Ok(city);
    }


    // --- country ---
    [HttpGet("country")]
    public ActionResult<string> AllCountries()
    {
      var countries = apiService.AllCountries();

      return Ok(countries);
    }

    [HttpGet("country/{id}")]
    public ActionResult<string> GetCountry(int id)
    {
      var country = apiService.GetCountry(id);

      return Ok(country);
    }


    // --- language ---
    [HttpGet("language")]
    public ActionResult<string> AllLanguages()
    {
      var languages = apiService.AllLanguages();

      return Ok(languages);
    }

    [HttpGet("language/{id}")]
    public ActionResult<string> GetLanguage(int id)
    {
      var language = apiService.GetLanguage(id);

      return Ok(language);
    }
  }
}
