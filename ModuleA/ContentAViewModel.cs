using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Infrastructure;
using System.ComponentModel;
using Main.Infrastructure.Services;
using System.Collections.ObjectModel;
using Business;

namespace ModuleA
{
  public class ContentAViewModel : IContentAViewModel, INotifyPropertyChanged
  {
    private readonly IPersonService _personService;

    #region Properties

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
                             

    private bool _IsBusy;

    public bool IsBusy
    {
      get { return _IsBusy; }
      set
      {
        _IsBusy = value;
        OnPropertyChanged("IsBusy");
      }
    }                               

    #endregion //Properties

    #region Constructors

    public ContentAViewModel(IPersonService personService)
    {
      _personService = personService;
      LoadPeople();
    }

    #endregion //Constructors

    #region Commands



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

    #endregion //Methods

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyname)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

    #endregion //INotifyPropertyChanged
  }

  ////Module 5
  //public class ContentAViewModel : IContentAViewModel
  //{                      
  //  public IView View { get; set; }
  //  public string Message { get; set; }

  //  public ContentAViewModel(IContentAView view)
  //  {
  //    View = view;
  //    View.ViewModel = this;
  //  }
  //}
}
