using BackEnd.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Repositories
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
          City = new City()
        },
        new Person
        {
          Id = 2,
          Name = "Bob",
          PhoneNumber = "2345679801",
          City = new City()
        },
        new Person
        {
          Id = 3,
          Name = "Carol",
          PhoneNumber = "3456789012",
          City = new City()
        },
        new Person
        {
          Id = 4,
          Name = "Dan",
          PhoneNumber = "4567890123",
          City = new City()
        }
      };
    }

    public Person Create(Person person)
    {
      Person newPerson = new Person
      {
        Id = people.Max(p => p.Id) + 1,
        Name= person.Name,
        PhoneNumber= person.PhoneNumber,
        City= person.City
      };

      people.Add(newPerson);

      return newPerson;
    }

    public IEnumerable<Person> Read()
    {
      return people;
    }

    public Person Read(int id)
    {
      return people.SingleOrDefault(p => p.Id == id);
    }

    public Person Update(Person person)
    {
      Person personOriginal = Read(person.Id);

      if (personOriginal == null)
        return null;

      personOriginal.Name = person.Name;
      personOriginal.PhoneNumber = person.PhoneNumber;
      personOriginal.City = person.City;

      return personOriginal;
    }

    public bool Delete(int id)
    {
      Person personOriginal = Read(id);

      if (personOriginal == null)
        return false;

      return people.Remove(personOriginal);
    }
  }
}
