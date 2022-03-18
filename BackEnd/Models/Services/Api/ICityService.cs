using BackEnd.Models.Dto;
using System.Collections.Generic;

namespace BackEnd.Models.Services.Api
{
  public interface ICityService
  {
    IEnumerable<CityDto> AllCities();
    CityDto GetCity(int id);
  }
}
