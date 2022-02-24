using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface ILanguageService
  {
    List<SelectListItem> LanguageList { get; }
    Language Add(LanguageCreateViewModel countryCreateViewModel);
    IEnumerable<Language> All();
    Language GetById(int id);
    bool Delete(int id);
    bool RemovePerson(int lig, int pid);
  }
}
