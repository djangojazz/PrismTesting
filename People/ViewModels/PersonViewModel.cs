using Business;
using Main.Infrastructure; 

namespace People
{
  public class PersonViewModel : ViewModelBase, IPersonViewModel
  {
    public PersonViewModel(IPersonView view)
        : base(view)
    {
      CreatePerson();
    }

    private Person _person;
    public Person Person
    {
      get { return _person; }
      set
      {
        _person = value;
        OnPropertyChanged("Person");
      }
    }

    private void CreatePerson()
    {
      Person = new Person()
      {
        FirstName = "Bob",
        LastName = "Smith",
        Age = 46
      };
    }
  }
}
