using Back_End.Models.Entities;
using System.Collections.Generic;

namespace Back_End.Models.Repositories
{
  public interface IPersonRepository
  {
    /// <summary>
    /// Creates a new Person with a unique Id and saves it to storage.
    /// </summary>
    /// <param name="person">Person to be created and stored</param>
    /// <returns>Returns created Person</returns>
    public Person Create(Person person);

    /// <summary>
    /// Returns list of stored People
    /// </summary>
    /// <returns>Returns list of stored People</returns>
    public IEnumerable<Person> Read();

    /// <summary>
    /// Finds the Person in the storage with the provided Id
    /// </summary>
    /// <param name="id">Id of Person to find</param>
    /// <returns>Returns Person if found, returns null if not found</returns>
    public Person Read(int id);

    /// <summary>
    /// Updates Person in storage and returns it.
    /// </summary>
    /// <param name="person">Person to be updated in storage</param>
    /// <returns>Returns updated Person, Returns null if Person can not be found</returns>
    public Person Update(Person person);

    /// <summary>
    /// Deletes Person with provided Id from storage if found.
    /// </summary>
    /// <param name="id">Id of Person to delete from storage</param>
    /// <returns>Returns True if deleted, False if not deleted</returns>
    public bool Delete(int id);
  }
}
