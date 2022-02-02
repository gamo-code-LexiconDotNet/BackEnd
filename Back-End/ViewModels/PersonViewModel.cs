using Back_End.Models;
using System.Collections.Generic;

namespace Back_End.ViewModels
{
  public class PersonViewModel
  {
    public IEnumerable<Person> People { get; set; }
    public string SearchTerm { get; set; }
    public bool CaseSensitive { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
  }
}
