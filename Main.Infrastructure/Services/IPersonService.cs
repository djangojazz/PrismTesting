using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Infrastructure.Services
{
  public interface IPersonService
  {
    IList<Person> GetPeople();
    void GetPeopleAsync(EventHandler<ServiceResult<IList<Person>>> callback);
  }
}                                                            