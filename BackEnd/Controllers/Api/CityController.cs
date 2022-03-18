using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackEnd.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class CityController : ControllerBase
  {
    private readonly ICityService cityService;

    public CityController(ICityService cityService)
    {
      this.cityService = cityService;
    }

    [HttpGet]
    public ActionResult<string> AllCities()
    {
      var cities = cityService.AllCities();

      if (cities == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(cities));
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetCity(int id)
    {
      var city = cityService.GetCity(id);

      if (city == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(city));
    }
  }
}
