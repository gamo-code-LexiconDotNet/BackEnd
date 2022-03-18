using BackEnd.Models.Dto;
using BackEnd.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services.Api
{
  public class LanguageService : ILanguageService
  {
    private readonly ILanguageRepository languageRepository;

    public LanguageService(ILanguageRepository languageRepository)
    {
      this.languageRepository = languageRepository;
    }

    public IEnumerable<LanguageDto> AllLanguages()
    {
      var languages = languageRepository.Read();

      if (languages == null)
        return null;

      return languages.Select(language => LanguageDto.Create(language));
    }

    public LanguageDto GetLanguage(int id)
    {
      return LanguageDto.Create(languageRepository.Read(id));
    }
  }
}
