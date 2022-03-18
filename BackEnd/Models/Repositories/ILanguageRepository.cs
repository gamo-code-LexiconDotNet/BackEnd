using BackEnd.Models.Entities;
using System.Collections.Generic;

namespace BackEnd.Models.Repositories
{
  public interface ILanguageRepository
  {
    public Language Create(Language person);
    public IEnumerable<Language> Read();
    public Language Read(int id);
    public Language Update(Language person);
    public bool Delete(int id);
  }
}
