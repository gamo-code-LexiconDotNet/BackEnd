using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services.Api
{
  public interface IPersonService
  {
    PersonDto AddPerson(PersonCreateDto personCreateDto);
    public IEnumerable<PersonDto> AllPersons();
    public PersonDto GetPerson(int id);
    public IEnumerable<object> PersonList();
    bool RemovePerson(int id);
  }
}
