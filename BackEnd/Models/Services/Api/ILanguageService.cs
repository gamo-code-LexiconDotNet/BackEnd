using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services.Api
{
  public interface ILanguageService
  {
    public IEnumerable<LanguageDto> AllLanguages();
    public LanguageDto GetLanguage(int id);
    public IEnumerable<object> LanguageList();
  }
}
