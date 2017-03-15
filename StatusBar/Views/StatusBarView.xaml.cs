using Main.Infrastructure;  
using System.Windows.Controls; 

namespace StatusBar
{
  /// <summary>
  /// Interaction logic for StatusBarView.xaml
  /// </summary>
  public partial class StatusBarView : UserControl, IStatusBarView
  {
    public StatusBarView()
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
