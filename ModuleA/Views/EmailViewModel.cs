using System;
using Main.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;

namespace ModuleA.Views
{
  public class EmailViewModel : ViewModelBase, IEmailViewModel, INavigationAware
  {
    private IRegionNavigationJournal _journal;

    #region Constructors

    public EmailViewModel()
    {
      CancelCommand = new DelegateCommand(Cancel);
    }

    private void Cancel()
    {
      _journal.GoBack();
    }

    #endregion //Constructors

    #region Properties
    public DelegateCommand CancelCommand { get; private set; }


    private string _to;
    public string To
    {
      get { return _to; }
      set
      {
        _to = value;
        OnPropertyChanged("To");
      }
    }

    private string _subject;
    public string Subject
    {
      get { return _subject; }
      set
      {
        _subject = value;
        OnPropertyChanged("Subject");
      }
    }

    private string _body;
    public string Body
    {
      get { return _body; }
      set
      {
        _body = value;
        OnPropertyChanged("Body");
      }
    }
              
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
      var toAddress = navigationContext.Parameters["To"];
      if (To == toAddress)
        return true;
      else
        return false;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
      
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
      _journal = navigationContext.NavigationService.Journal;

      var toAddress = navigationContext.Parameters["To"];
      if (!string.IsNullOrWhiteSpace(toAddress))
        To = toAddress;
      else
        To = "Email not provided.";
    }

    #endregion //Properties
  }
}
