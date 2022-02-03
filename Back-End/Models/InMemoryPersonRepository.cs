using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models
{
  public class InMemoryPersonRepository : IPersonRepository
  {
    private readonly List<Person> people;

    public InMemoryPersonRepository()
    {
      people = new List<Person>()
      {
        new Person
        {
          Id = 1,
          Name = "Alice",
          PhoneNumber = "1234567890",
          City = "Amsterdam"
        },
        new Person
        {
          Id = 2,
          Name = "Bob",
          PhoneNumber = "2345679801",
          City = "Berlin"
        },
        new Person
        {
          Id = 3,
          Name = "Carol",
          PhoneNumber = "3456789012",
          City = "Copenhagen"
        },
        new Person
        {
          Id = 4,
          Name = "Dan",
          PhoneNumber = "4567890123",
          City = "Dublin"
        }
      };
    }

    public void Add(Person person)
    {
      people.Add(person);
      person.Id = people.Max(p => p.Id) + 1;
    }

    public IEnumerable<Person> Search(string searchTerm, bool caseSensitive)
    {
      StringComparison stringComparison = StringComparison.CurrentCulture;
      
      if (!caseSensitive)
        stringComparison = StringComparison.CurrentCultureIgnoreCase;

      return from p in people
             where
               string.IsNullOrEmpty(searchTerm)
               || p.Name.Contains(searchTerm, stringComparison)
               || p.PhoneNumber.Contains(searchTerm, stringComparison)
               || p.City.Contains(searchTerm, stringComparison)
             select p;
    }

    public IEnumerable<Person> All()
    {
      return people.OrderBy(p => p.Name);
    }

    public IEnumerable<Person> OrderAllBy(string sortOrder)
    {
      switch (sortOrder)
      {
        case "name_desc": return people.OrderByDescending(p => p.Name);
        case "City": return people.OrderBy(p => p.City); ;
        case "city_desc": return people.OrderByDescending(p => p.City);
        default: return people.OrderBy(p => p.Name); ;
      }
    }

    public bool Delete(int id)
    {
      Person person = GetById(id);

      if (person == null)
        return false;

      return people.Remove(person);
    }

    public Person GetById(int id)
    {
      return people.SingleOrDefault(p => p.Id == id);
    }
  }
}
