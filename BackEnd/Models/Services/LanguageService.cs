using BackEnd.Models.Entities;
using BackEnd.Models.Repositories;
using BackEnd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services
{
  public class LanguageService : ILanguageService
  {
    private readonly ILanguageRepository languageRepository;

    public LanguageService(ILanguageRepository languageRepository)
    {
      this.languageRepository = languageRepository;
    }

    public Language Add(LanguageCreateViewModel languageCreateViewModel)
    {
      Language language = new Language();

      // 0. Rename Language
      if (
        !string.IsNullOrWhiteSpace(languageCreateViewModel.LanguageName)
        && languageCreateViewModel.LanguageId > 0)
      {
        language = languageRepository.Read(languageCreateViewModel.LanguageId);

        if (language == null)
          return null;

        language.Name = languageCreateViewModel.LanguageName;

        return languageRepository.Update(language);
      }

      // 1. No language
      if (
        string.IsNullOrWhiteSpace(languageCreateViewModel.LanguageName)
        && languageCreateViewModel.LanguageId < 1)
      {
        return null;
      }

      // 2. Update relationship
      else if (
        languageCreateViewModel.LanguageId > 0
        && languageCreateViewModel.PersonId > 0)
      {
        language = languageRepository.Read(languageCreateViewModel.LanguageId);

        if (!language.PeopleLanguages.Any(
            pl =>
            pl.PersonId == languageCreateViewModel.PersonId
            && pl.LanguageId == languageCreateViewModel.LanguageId))
          language.PeopleLanguages.Add(new PersonLanguage
          {
            PersonId = languageCreateViewModel.PersonId,
            LanguageId = languageCreateViewModel.LanguageId
          });

        // perform update instead of insert
        return languageRepository.Update(language);
      }

      // 3. New language with person relationship
      else if (
        !string.IsNullOrWhiteSpace(languageCreateViewModel.LanguageName)
        && languageCreateViewModel.PersonId > 0)
      {
        language.Name = languageCreateViewModel.LanguageName;
        language.PeopleLanguages = new List<PersonLanguage>();
        language.PeopleLanguages.Add(new PersonLanguage
        {
          PersonId = languageCreateViewModel.PersonId
        });
      }

      // 4. New language without relationship
      else if (
        !string.IsNullOrWhiteSpace(languageCreateViewModel.LanguageName)
        && languageCreateViewModel.LanguageId < 1
        && languageCreateViewModel.PersonId < 1)
      {
        language.Name = languageCreateViewModel.LanguageName;
      }

      // 5. default
      else
        return null;

      return languageRepository.Create(language);
    }

    public IEnumerable<Language> All()
    {
      return languageRepository.Read().OrderBy(l => l.Name);
    }

    public bool Delete(int id)
    {
      return languageRepository.Delete(id);
    }

    public Language GetById(int id)
    {
      return languageRepository.Read(id);
    }

    public bool RemovePerson(int lid, int pid)
    {
      var language = languageRepository.Read(lid);

      if (language == null)
        return false;

      language.PeopleLanguages =
        language
        .PeopleLanguages
        .Where(pl => pl.PersonId != pid)
        .ToList();

      languageRepository.Update(language);

      return true;
    }

    public List<SelectListItem> LanguageList
    {
      get
      {
        List<SelectListItem> list = new SelectList(All(), "Id", "Name").OrderBy(i => i.Text).ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose language" });
        return list;
      }
    }
  }
}
