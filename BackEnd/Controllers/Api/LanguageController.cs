using BackEnd.Models.Services.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

      return Ok(languages);
    }

    [HttpGet("{id}")]
    public ActionResult<string> GetLanguage(int id)
    {
      var language = languageService.GetLanguage(id);

      if (language == null)
        return NotFound();

      return Ok(language);
    }
  }
}
