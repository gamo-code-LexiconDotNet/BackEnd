using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountryController : ControllerBase
  {
    private readonly ICountryService countryService;

    public CountryController(ICountryService countryService)
    {
      this.countryService = countryService;
    }

    [HttpGet]
    public ActionResult<string> AllCountries()
    {
      var countries = countryService.AllCountries();

      if (countries == null)
        return NotFound();

      return Ok(countries);
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetLanguage(int id)
    {
      var country = countryService.GetCountry(id);

      if (country == null)
        return NotFound();

      return Ok(country);
    }
  }
}
