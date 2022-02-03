using System.Collections.Generic;

namespace Back_End.Models
{
  public interface IPersonRepository
  {
    public IEnumerable<Person> All();
    public IEnumerable<Person> Search(string searchTerm, bool caseSensitive);
    public void Add(Person newPerson);
    public IEnumerable<Person> OrderAllBy(string sortOrder);
    public bool Delete(int id);
    public Person GetById(int id);
  }
}
