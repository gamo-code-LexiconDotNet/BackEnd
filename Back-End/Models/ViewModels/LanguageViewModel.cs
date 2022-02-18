using Back_End.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.ViewModels
{
  public class LanguageViewModel
  {
    public LanguageViewModel() { }

    public IEnumerable<Language> Languages { get; set; }
    public List<SelectListItem> LanguageList { get; set; }
    public List<SelectListItem> PersonList { get; set; }
    
    public LanguageCreateViewModel languageCreateViewModel;
  }
}
