using Back_End.Models.Entities;
using Back_End.Models.Repositories;
using Back_End.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    public Person AddAndUpdate(PersonCreateViewModel vm)
    {
      bool hasName = !string.IsNullOrEmpty(vm.Name);
      bool hasId = vm.Id > 0;
      bool hasPhoneNumber = !string.IsNullOrEmpty(vm.PhoneNumber);
      bool hasCityName = !string.IsNullOrEmpty(vm.CityName);
      bool hasCityId = vm.CityId > 0;
      bool hasCountryName = !string.IsNullOrEmpty(vm.CountryName);
      bool hasCountryId = vm.CountryId > 0;
      bool hasLanguageName = !string.IsNullOrEmpty(vm.LanguageName);
      bool hasLanguageId = vm.LanguageId > 0;

      Person person = new Person();
      bool update = false;

      // --- person ---
      if (!hasId && !hasName)
        return null;

      if (hasId)
      {
        person = personRepository.Read(vm.Id);
        update = true;

        if (person == null)
          return null;
      }

      if (hasName)
      {
        person.Name = vm.Name;
      }

      // --- phone ---
      if (!update && !hasPhoneNumber)
        return null;

      if (hasPhoneNumber)
        person.PhoneNumber = vm.PhoneNumber;

      // --- city ---
      if (!update
        && !hasCityName
        && !hasCityId)
        return null;

      if (!update && hasCityName)
      {
        person.City = new City();
      }

      if (hasCityName)
      {
        person.City.Name = vm.CityName;
      }
      else if (hasCityId)
      {
        person.CityId = vm.CityId;
      }

      // --- country ---
      if (hasCityName)
      {
        if (!hasCountryName
          && !hasCountryId)
          return null;

        if (!update && hasCountryName)
        {
          person.City.Country = new Country();
        }

        if (hasCountryName)
        {
          person.City.Country.Name = vm.CountryName;
        }
        else if (hasCountryId)
        {
          person.City.CountryId = vm.CountryId;
        }
      }

      // --- language ---
      if (hasLanguageName)
      {
        if (!update)
        {
          person.PeopleLanguages = new List<PersonLanguage>();
        }

        person.PeopleLanguages.Add(new PersonLanguage
        {
          Langauge = new Language
          {
            Name = vm.LanguageName
          }
        });
      }
      else if (hasLanguageId)
      {
        if (person.PeopleLanguages == null)
          person.PeopleLanguages = new List<PersonLanguage>();

        person.PeopleLanguages.Add(new PersonLanguage
        {
          LanguageId = vm.LanguageId
        });
      }

      if (update)
        return personRepository.Update(person);
      else
        return personRepository.Create(person);
    }

    public bool AddLanguage(ref Person person, PersonCreateViewModel vm)
    {
      if (vm == null
        || person == null
        || string.IsNullOrEmpty(vm.LanguageName))
        return false;

      person.PeopleLanguages.Add(
        new PersonLanguage
        {
          Langauge = new Language { Name = vm.LanguageName }
        });

      return true;
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

    public List<SelectListItem> PersonList
    {
      get
      {
        List<SelectListItem> list = new SelectList(All(), "Id", "Name").OrderBy(c => c.Text).ToList();
        list.Insert(0, new SelectListItem { Value = "0", Text = "Choose person" });
        return list;
      }
    }
  }
}