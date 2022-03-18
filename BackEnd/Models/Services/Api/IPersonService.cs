using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services.Api
{
  public interface IPersonService
  {
    public IEnumerable<PersonDto> AllPersons();
    public PersonDto GetPerson(int id);
  }
}
