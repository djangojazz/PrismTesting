using Business;
using Main.Infrastructure;     

namespace People
{
  public interface IPersonDetailsViewModel : IViewModel
  {
    Person SelectedPerson { get; set; }
  }
}
