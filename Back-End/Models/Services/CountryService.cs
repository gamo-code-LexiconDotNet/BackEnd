using Back_End.Models.Entities;
using Back_End.Models.Repositories;
using Back_End.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Services
{
  public class CountryService : ICountryService
  {
    private readonly ICountryRepository countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
      this.countryRepository = countryRepository;
    }

    public Country Add(CountryCreateViewModel countryCreateVM)
    {
      if (string.IsNullOrWhiteSpace(countryCreateVM.Name))
        return null;

      return countryRepository.Create(new Country
      {
        Name = countryCreateVM.Name
      });
    }

    public IEnumerable<Country> All()
    {
      return countryRepository.Read().OrderBy(c => c.Name);
    }

    public Country GetById(int id)
    {
      return countryRepository.Read(id);
    }

    public bool Delete(int id)
    {
      return countryRepository.Delete(id);
    }
  }
}
