using Main.Infrastructure;
using System.Windows.Controls; 

namespace ModuleA.Views
{
  /// <summary>
  /// Interaction logic for EmailView.xaml
  /// </summary>
  public partial class EmailView : UserControl, IView
  {
    public EmailView(IEmailViewModel viewModel)
    {
      InitializeComponent();
      ViewModel = viewModel;
    }

    public IViewModel ViewModel
    {
      get { return (IViewModel)DataContext; }
      set { DataContext = value; }
    }
  }
}
