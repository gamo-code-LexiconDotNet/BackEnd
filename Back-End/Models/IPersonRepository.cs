using System.Collections.Generic;

namespace Back_End.Models
{
  public interface IPersonRepository
  {
    public IEnumerable<Person> All();
    public void Add(Person newPerson);
    public bool Delete(int id);
    public Person GetById(int id);
    public IEnumerable<Person> SearchAndOrder(
      string searchTerm, bool caseSensitive, string sortOrder);
  }
}
