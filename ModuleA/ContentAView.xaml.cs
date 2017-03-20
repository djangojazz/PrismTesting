using Main.Infrastructure;  
using System.Windows.Controls;   

namespace ModuleA
{
  /// <summary>
  /// Interaction logic for ContentAView.xaml
  /// </summary>
  public partial class ContentAView : UserControl, IContentAView
  {
    public ContentAView(IContentAViewModel viewModel)
    {
      InitializeComponent();
      ViewModel = viewModel;
    }

    public IViewModel ViewModel
    {
      get { return (IContentAViewModel)DataContext; }
      set { DataContext = value; }
    }
  }
}
