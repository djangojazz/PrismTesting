using Main.Infrastructure;
using System;             
using Business;

namespace Services
{
  public class PersonRepository : IPersonRepository
  {
    int count = 0;

    public int SavePerson(Person person)
    {
      count++;
      person.LastUpdated = DateTime.Now;
      return count;
    }

    
  }
}
