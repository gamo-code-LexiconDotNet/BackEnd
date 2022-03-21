using BackEnd.Models.Dto;
using BackEnd.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Models.Services.Api
{
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository personRepository;

    public PersonService(IPersonRepository personRepository)
    {
      this.personRepository = personRepository;
    }

    public IEnumerable<PersonDto> AllPersons()
    {
      var persons = personRepository.Read();

      if (persons == null)
        return null;

      return persons.Select(person => PersonDto.Create(person));
    }

    public PersonDto GetPerson(int id)
    {
      return PersonDto.Create(personRepository.Read(id));
    }

    public IEnumerable<object> PersonList()
    {
      return from person in personRepository.Read()
             orderby person.Name
             select new { id = person.Id, name = person.Name };
    }

    public PersonDto AddPerson(PersonCreateDto personCreateDto)
    {
      var person = personCreateDto.ToEntity();

      var newPerson = personRepository.Create(person);

      return PersonDto.Create(newPerson);
    }

    public bool RemovePerson(int id)
    {
      return personRepository.Delete(id);
    }
  }
}
