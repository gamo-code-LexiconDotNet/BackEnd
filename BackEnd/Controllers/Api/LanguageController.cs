using BackEnd.Models.Dto;
using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Controllers.Api
{
  [Route("api/[controller]")]
  [ApiController]
  public class LanguageController : ControllerBase
  {
    private readonly ILanguageService languageService;

    public LanguageController(ILanguageService languageService)
    {
      this.languageService = languageService;
    }

    [HttpGet]
    public ActionResult<string> AllLanguages()
    {
      var languages = languageService.AllLanguages();

      if (languages == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(languages));
    }

    [HttpGet("list")]
    public ActionResult<string> LanguagesList()
    {
      var languagelist = languageService.LanguageList();

      if (languagelist == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(languagelist));
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetLanguage(int id)
    {
      var language = languageService.GetLanguage(id);

      if (language == null)
        return NotFound();

      return Ok(JsonConvert.SerializeObject(language));
    }
  }
}
