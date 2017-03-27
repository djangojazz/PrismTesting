using Business;
using Main.Infrastructure;
using Main.Infrastructure.Services;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions; 
using ModuleA.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace ModuleA
{
  public class ViewAViewModel : ViewModelBase, IViewAViewModel//, IConfirmNavigationRequest
  {
    private readonly IRegionManager _regionManager;
    private readonly IPersonService _personService;

    #region Constructors

    public ViewAViewModel(IRegionManager regionManager, IPersonService personService)
    {
      _regionManager = regionManager;
      _personService = personService;
      EmailCommand = new DelegateCommand<Person>(Email);
      LoadPeople();
    }

    #endregion //Constructors

    #region Properties
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

    private ObservableCollection<Person> _People;
    public ObservableCollection<Person> People
    {
      get { return _People; }
      set
      {
        _People = value;
        OnPropertyChanged("People");
      }
    }

    public DelegateCommand<Person> EmailCommand { get; private set; }

    #endregion //Properties

    #region Commands

    private void Email(Person person)
    {
      if (person != null)
      {
        var uriQuery = new UriQuery();
        uriQuery.Add("To", person.Email);

        var uri = new Uri(typeof(EmailView).FullName + uriQuery, UriKind.Relative);
        _regionManager.RequestNavigate(RegionNames.ContentRegion, uri);
      }
    }

    #endregion //Commands

    #region Methods

    private void LoadPeople()
    {
      IsBusy = true;
      _personService.GetPeopleAsync((sender, result) =>
      {
        People = new ObservableCollection<Person>(result.Object);
        IsBusy = false;
      });
    }

    //public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    //{
    //  bool result = true;

    //  if (MessageBox.Show("Do you want to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
    //    result = false;

    //  continuationCallback(result);
    //}
      
    //public bool IsNavigationTarget(NavigationContext navigationContext)
    //{
    // return true;
    //}

    //public void OnNavigatedFrom(NavigationContext navigationContext)
    //{                                          
    //}

    //public void OnNavigatedTo(NavigationContext navigationContext)
    //{
    //  PageViews++;
    //}

    #endregion //Methods
  }
}
