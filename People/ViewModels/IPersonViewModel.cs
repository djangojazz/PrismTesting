using Main.Infrastructure;

namespace People
{
  public interface IPersonViewModel : IViewModel
  {
    void CreatePerson(string firstName, string lastName);
  }
}
