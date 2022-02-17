using Back_End.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Back_End.Models.ViewModels
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
    public SelectList Cities { get; set; }
    public SelectList Countries { get; set; }


    public PersonCreateViewModel personCreateViewModel;
  }
}
