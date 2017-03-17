using Business;
using Main.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
  public class PersonDetailsViewModel : ViewModelBase, IPersonDetailsViewModel
  {
    public PersonDetailsViewModel() { }

    private Person _SelectedPerson;
    public Person SelectedPerson
    {
      get { return _SelectedPerson; }
      set
      {
        _SelectedPerson = value;
        OnPropertyChanged("SelectedPerson");
      }
    }
  }
}
