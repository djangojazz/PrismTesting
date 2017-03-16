using System.Windows.Controls;
using Main.Infrastructure;

namespace Toolbar
{
  /// <summary>
  /// Interaction logic for ToolbarView.xaml
  /// </summary>
  public partial class ToolbarView : UserControl, IToolbarView
  {
    public ToolbarView()
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
