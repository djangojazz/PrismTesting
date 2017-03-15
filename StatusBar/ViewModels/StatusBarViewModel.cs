using Main.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBar
{
  public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
  {
    public StatusBarViewModel(IStatusBarView view)
        : base(view)
    {
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
