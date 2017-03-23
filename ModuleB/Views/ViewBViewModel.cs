using System;
using Main.Infrastructure;
using Microsoft.Practices.Prism.Regions;

namespace ModuleB
{
  public class ViewBViewModel : ViewModelBase, IViewBViewModel, INavigationAware, IRegionMemberLifetime
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

    public bool KeepAlive => false;

    public ViewBViewModel()
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
