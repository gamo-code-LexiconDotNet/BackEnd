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
  }
}
