using Main.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
  public class ViewAViewModel : ViewModelBase, IViewAViewModel, INavigationAware
  {
    private int _pageViews;
    public int PageViews
    {
      get { return _pageViews; }
      set
      {
        _pageViews = value;
        OnPropertyChanged("PageViews");
      }
    }

    public ViewAViewModel()
    {

    }
           
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
      return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
      
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      PageViews++;
    }
  }
}
