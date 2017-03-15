using Main.Infrastructure;   
using System.Windows.Controls; 

namespace People
{
  /// <summary>
  /// Interaction logic for PersonView.xaml
  /// </summary>
  public partial class PersonView : UserControl, IPersonView           
  {
    public PersonView()
    {
      InitializeComponent();
    }

    public IViewModel ViewModel
    {
      get { return (IViewModel)DataContext; }
      set { DataContext = value; }
    }
  }
}
