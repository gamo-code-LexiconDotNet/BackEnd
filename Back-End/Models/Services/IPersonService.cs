using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface IPersonService
  {
    public IEnumerable<Person> All();
    public Person Add(PersonCreateViewModel personCreateVM);
    public bool Delete(int id);
    public Person GetById(int id);
    public IEnumerable<Person> SearchAndOrder(
      string searchTerm, bool caseSensitive, string sortOrder);
  }
}
