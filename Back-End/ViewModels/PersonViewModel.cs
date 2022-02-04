using Back_End.Models;
using System.Collections.Generic;

namespace Back_End.ViewModels
{
  public class PersonViewModel
  {
    public PersonViewModel() { }

    public IEnumerable<Person> People { get; set; }
    public string SearchTerm { get; set; }
    public bool CaseSensitive { get; set; } = false;
    public string NameSortParam { get; set; }
    public string CitySortParam { get; set; }

    public PersonCreateViewModel personCreateViewModel;
  }
}
