using System;
using Main.Infrastructure;
using Microsoft.Practices.Prism.Regions;

namespace ModuleA.Views
{
  public class EmailViewModel : ViewModelBase, IEmailViewModel, INavigationAware
  {
    #region Constructors

    public EmailViewModel()
    {

    }

    #endregion //Constructors

    #region Properties

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
      var toAddress = navigationContext.Parameters["To"];
      if (!string.IsNullOrWhiteSpace(toAddress))
        To = toAddress;
      else
        To = "Email not provided.";
    }

    #endregion //Properties
  }
}
