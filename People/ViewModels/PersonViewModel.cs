using System;
using Business;
using Main.Infrastructure;
using Microsoft.Practices.Prism.Commands;
using System.ComponentModel;
using Microsoft.Practices.Prism.Events;
using System.Windows;

namespace People
{
  public class PersonViewModel : ViewModelBase, IPersonViewModel
  {
    IEventAggregator _eventAggregator;

    public string ViewName
    {
      get
      {
        return string.Format("{0}, {1}", Person.LastName, Person.FirstName);
      }
    }

    public DelegateCommand SaveCommand { get; set; }
    IPersonRepository _repository;

    public PersonViewModel(IPersonView view, IEventAggregator eventAggregator, IPersonRepository repository)
        : base(view)
    {
      _repository = repository;
      _eventAggregator = eventAggregator;
      SaveCommand = new DelegateCommand(Save, CanSave);
      GlobalCommands.SaveAllCommand.RegisterCommand(SaveCommand);
    }

    private void Save()
    {
      int count = _repository.SavePerson(Person);
      MessageBox.Show(count.ToString());
      _eventAggregator.GetEvent<PersonUpdatedEvent>().Publish($"{Person.LastName}, {Person.FirstName}");
    }
    private bool CanSave()
    {
      return Person != null && Person.Error == null;
    }

    private Person _person;
    public Person Person
    {
      get { return _person; }
      set
      {
        _person = value;
        _person.PropertyChanged += Person_PropertyChanged;
        OnPropertyChanged("Person");
      }
    }

    void Person_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      SaveCommand.RaiseCanExecuteChanged();
    }

    public void CreatePerson(string firstName, string lastName)
    {
      Person = new Person()
      {
        FirstName = firstName,
        LastName = lastName,
        Age = 0
      };
    }
  }
}
