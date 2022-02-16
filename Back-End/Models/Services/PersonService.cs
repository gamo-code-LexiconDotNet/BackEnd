using Back_End.Models.Entities;
using Back_End.Models.Repositories;
using Back_End.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Services
{
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository personRepository;

    public PersonService(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    public Person Add(PersonCreateViewModel personCreateVM)
    {
      if (
        string.IsNullOrWhiteSpace(personCreateVM.Name)
        || string.IsNullOrWhiteSpace(personCreateVM.PhoneNumber)
        || string.IsNullOrWhiteSpace(personCreateVM.City)
      )
        return null;

      return personRepository.Create(new Person()
      {
        Name = personCreateVM.Name,
        PhoneNumber = personCreateVM.PhoneNumber,
        City = new City { Name = personCreateVM.City }
      });
    }

    public IEnumerable<Person> All()
    {
      return personRepository.Read().OrderBy(p => p.Name);
    }

    public bool Delete(int id)
    {
      return personRepository.Delete(id);
    }

    public Person GetById(int id)
    {
      return personRepository.Read(id);
    }

    public IEnumerable<Person> SearchAndOrder(
      string searchTerm, bool caseSensitive, string sortOrder)
    {
      StringComparison stringComparison = StringComparison.CurrentCulture;

      if (!caseSensitive)
        stringComparison = StringComparison.CurrentCultureIgnoreCase;

      IEnumerable<Person> result = from p in personRepository.Read()
                                   where
                                     string.IsNullOrEmpty(searchTerm)
                                     || p.Name.Contains(searchTerm, stringComparison)
                                     || p.PhoneNumber.Contains(searchTerm, stringComparison)
                                     || p.City.Name.Contains(searchTerm, stringComparison)
                                   select p;

      switch (sortOrder)
      {
        case "name_desc": return result.OrderByDescending(p => p.Name);
        case "city": return result.OrderBy(p => p.City.Name); ;
        case "city_desc": return result.OrderByDescending(p => p.City.Name);
        default: return result.OrderBy(p => p.Name);
      }
    }
  }
}