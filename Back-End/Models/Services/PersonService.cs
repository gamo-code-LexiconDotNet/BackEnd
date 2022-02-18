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

    public Person Add(PersonCreateViewModel pcvm)
    {
      Person person = new Person();
      bool update = false;

      // --- person ---
      if (!string.IsNullOrWhiteSpace(pcvm.Name))
      {
        person.Name = pcvm.Name;
      }
      else if (pcvm.Id > 0)
      {
        person = personRepository.Read(pcvm.Id);
        update = true;
        if (person == null)
          return null;
      }
      else
        return null;

      // --- phone ---
      if (!update && string.IsNullOrWhiteSpace(pcvm.PhoneNumber))
        return null;

      if (!string.IsNullOrWhiteSpace(pcvm.PhoneNumber))
        person.PhoneNumber = pcvm.PhoneNumber;

      // --- city ---
      if (!update
        && string.IsNullOrWhiteSpace(pcvm.CityName)
        && pcvm.CityId < 1)
        return null;

      if (!update && !string.IsNullOrWhiteSpace(pcvm.CityName))
      {
        person.City = new City();
      }

      if (!string.IsNullOrWhiteSpace(pcvm.CityName))
      {
        person.City.Name = pcvm.CityName;
      }
      else if (pcvm.CityId > 0)
      {
        person.CityId = pcvm.CityId;
      }

      // --- country ---
      if (!string.IsNullOrWhiteSpace(pcvm.CityName))
      {
        if (string.IsNullOrWhiteSpace(pcvm.CountryName)
          && pcvm.CountryId < 1)
          return null;

        if (!update && !string.IsNullOrWhiteSpace(pcvm.CountryName))
        {
          person.City.Country = new Country();
        }

        if (!string.IsNullOrWhiteSpace(pcvm.CountryName))
        {
          person.City.Country.Name = pcvm.CountryName;
        }
        else if (pcvm.CountryId > 0)
        {
          person.City.CountryId = pcvm.CountryId;
        }
      }

      // language
      if (!string.IsNullOrWhiteSpace(pcvm.LanguageName))
      {
        if (!update)
        {
          person.PeopleLanguages = new List<PersonLanguage>();
        }

        person.PeopleLanguages.Add(new PersonLanguage
        {
          Langauge = new Language
          {
            Name= pcvm.LanguageName
          }
        });
      }
      else if (pcvm.LanguageId > 0)
      {
        person.PeopleLanguages.Add(new PersonLanguage
        {
          LanguageId = pcvm.LanguageId
        });
      }

      if (update)
        return personRepository.Update(person);
      else
        return personRepository.Create(person);
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

      var people = personRepository.Read();


      IEnumerable<Person> result =
        from p in people
        where
          string.IsNullOrEmpty(searchTerm)
          || p.Name.Contains(searchTerm, stringComparison)
          || p.PhoneNumber.Contains(searchTerm, stringComparison)
          || p.City.Name.Contains(searchTerm, stringComparison)
          || p.City.Country.Name.Contains(searchTerm, stringComparison)
          || p.PeopleLanguages.Where(pl => pl.Langauge.Name.Contains(searchTerm, stringComparison)).Any()
        select p;

      switch (sortOrder)
      {
        case "name_desc": return result.OrderByDescending(p => p.Name);
        case "city": return result.OrderBy(p => p.City.Name); ;
        case "city_desc": return result.OrderByDescending(p => p.City.Name);
        case "country": return result.OrderBy(p => p.City.Country.Name); ;
        case "country_desc": return result.OrderByDescending(p => p.City.Country.Name);
        default: return result.OrderBy(p => p.Name);
      }
    }

    public bool RemoveLanguage(int lid, int pid)
    {
      var person = personRepository.Read(pid);

      if (person == null)
        return false;

      person.PeopleLanguages =
        person
        .PeopleLanguages
        .Where(pl => pl.LanguageId != lid)
        .ToList();

      personRepository.Update(person);

      return true;
    }
  }
}