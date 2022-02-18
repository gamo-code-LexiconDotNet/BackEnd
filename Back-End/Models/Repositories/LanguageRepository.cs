using Back_End.Models.Data;
using Back_End.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Repositories
{
  public class LanguageRepository : ILanguageRepository
  {
    private readonly AppDbContext appDbContext;

    public LanguageRepository(AppDbContext appDbContext)
    {
      this.appDbContext = appDbContext;
    }

    public Language Create(Language language)
    {
      var newLanguage = appDbContext.Languages.Add(language);

      appDbContext.SaveChanges();

      return newLanguage.Entity;
    }

    public IEnumerable<Language> Read()
    {
      return appDbContext
        .Languages
        .Include(l => l.PeopleLanguages)
        .ThenInclude(pl => pl.Person);
    }

    public Language Read(int id)
    {
      return appDbContext
        .Languages
        .Include(l => l.PeopleLanguages)
        .ThenInclude(l => l.Person)
        .FirstOrDefault(l => l.Id == id);
    }

    public Language Update(Language language)
    {
      var entry = appDbContext.Entry<Language>(language);
      entry.State = EntityState.Modified;

      appDbContext.SaveChanges();

      return entry.Entity;
    }

    public bool Delete(int id)
    {
      var language = appDbContext.Languages.Find(id);

      if (language == null)
        return false;

      appDbContext.Remove(language);
      appDbContext.SaveChanges();

      return true;
    }
  }
}
