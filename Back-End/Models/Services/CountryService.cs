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

    public Country AddOrUpdate(CountryCreateViewModel viewModel)
    {
      if (!string.IsNullOrWhiteSpace(viewModel.Name)
        && viewModel.Id > 0)
        return Update(viewModel);

      return Add(viewModel);
    }

    public bool RemoveCity(int countryId, int cityId)
    {
      var country = countryRepository.Read(countryId);

      if (country == null)
        return false;

      country.Cities = 
        country.Cities
        .Where(c => c.Id != cityId)
        .ToList();

      countryRepository.Update(country);

      return true;
    }

    public Country Add(CountryCreateViewModel viewModel)
    {
      if (string.IsNullOrWhiteSpace(viewModel.Name))
        return null;

      return countryRepository.Create(new Country
      {
        Name = viewModel.Name
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

    public Country Update(CountryCreateViewModel viewModel)
    {
      Country country = countryRepository.Read(viewModel.Id);

      if (country == null)
        return null;

      country.Name = viewModel.Name;
      country.Id = viewModel.Id;

      return countryRepository.Update(country);
    }

    public bool Delete(int id)
    {
      return countryRepository.Delete(id);
    }
  }
}
