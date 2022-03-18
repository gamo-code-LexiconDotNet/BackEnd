using BackEnd.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BackEnd.Models.ViewModels
{
  public class PersonViewModel
  {
    public PersonViewModel() { }

    public IEnumerable<Person> People { get; set; }
    public string SearchTerm { get; set; }
    public bool CaseSensitive { get; set; } = false;
    public string NameSortParam { get; set; }
    public string CitySortParam { get; set; }
    public string CountrySortParam { get; set; }
    public List<SelectListItem> CityList { get; set; }
    public List<SelectListItem> CountryList { get; set; }
    public List<SelectListItem> PersonList { get; set; }
    public List<SelectListItem> LanguageList { get; set; }

    public PersonCreateViewModel personCreateViewModel;
  }
}
