using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Infrastructure
{
  public class ViewModelBase : IViewModel, INotifyPropertyChanged
  {
    ////Used with Module 7
    //public IView View { get; set; }

    //public ViewModelBase() { }

    //public ViewModelBase(IView view)
    //{
    //  View = view;
    //  View.ViewModel = this;
    //}

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
