using Back_End.Models.Entities;
using Back_End.Models.ViewModels;
using System.Collections.Generic;

namespace Back_End.Models.Services
{
  public interface IPersonService
  {
    /// <summary>
    /// Returns list of all people
    /// </summary>
    /// <returns>List of people</returns>
    public IEnumerable<Person> All();

    /// <summary>
    /// Adds new Person.
    /// </summary>
    /// <param name="personCreateVM">Create view model of Person to be added</param>
    /// <returns>Returns added Person or null if it fails</returns>
    public Person Add(PersonCreateViewModel personCreateVM);

    /// <summary>
    /// Delete Person with provided Id
    /// </summary>
    /// <param name="id">Id of Person to delete</param>
    /// <returns>Returns True if Person was deleted or False if it was not deleted or Person does not excist.</returns>
    public bool Delete(int id);

    /// <summary>
    /// Gets the Person with the provided Id.
    /// </summary>
    /// <param name="id">Id of a Person</param>
    /// <returns>Returns Person with same Id or null if not able to get it</returns>
    public Person GetById(int id);

    /// <summary>
    /// Returns a filtered and sorted list of people.
    /// </summary>
    /// <param name="searchTerm">Search term to filter list by</param>
    /// <param name="caseSensitive">Case sensitivity of search term</param>
    /// <param name="sortOrder">List sort order</param>
    /// <returns>Returns list of people filtered by searchTerm and caseSensitive and ordered by sortOrder</returns>
    public IEnumerable<Person> SearchAndOrder(
      string searchTerm, bool caseSensitive, string sortOrder);
  }
}
