using Back_End.Models.Data;
using Back_End.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Back_End.Models.Repositories
{
  public class PersonRepository : IPersonRepository
  {
    private readonly AppDbContext appDbContext;

    public PersonRepository(AppDbContext appDbContext)
    {
      this.appDbContext = appDbContext;
    }

    public Person Create(Person person)
    {
      var newPerson = appDbContext.People.Add(person);

      appDbContext.SaveChanges();

      return newPerson.Entity;
    }

    public bool Delete(int id)
    {
      var person = appDbContext.People.Find(id);

      if (person == null)
        return false;

      appDbContext.Remove(person);
      appDbContext.SaveChanges();
      return true;
    }

    public IEnumerable<Person> Read()
    {
      return appDbContext
        .People
        .Include(p => p.City)
        .ThenInclude(c => c.Country)
        .Include(p => p.PeopleLanguages)
        .ThenInclude(pl => pl.Langauge);
    }

    public Person Read(int id)
    {
      return appDbContext
       .People
       .Include(p => p.City)
       .ThenInclude(c => c.Country)
       .Include(p => p.PeopleLanguages)
       .ThenInclude(pl => pl.Langauge)
       .FirstOrDefault(p => p.Id == id);
    }

    public Person Update(Person person)
    {
      var entry = appDbContext.Entry(person);
      entry.State = EntityState.Modified;
      appDbContext.SaveChanges();
      return entry.Entity;
    }
  }
}
