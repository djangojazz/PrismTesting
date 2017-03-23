using Main.Infrastructure;
using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBar
{
  public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
  {
    IEventAggregator _eventAggregator;

    public StatusBarViewModel(IStatusBarView view, IEventAggregator eventAggregator)
        //: base(view) Module 7
    {
      _eventAggregator = eventAggregator;
      _eventAggregator.GetEvent<PersonUpdatedEvent>().Subscribe(PersonUpdated);
    }

    private void PersonUpdated(string obj)
    {
      Message = $"{obj} was updated";
    }

    private string _message = "Ready";
    public string Message
    {
      get { return _message; }
      set
      {
        _message = value;
        OnPropertyChanged("Message");
      }
    }
  }
}
