using Business;
using Main.Infrastructure;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using System.Windows.Controls;  

namespace People
{
  /// <summary>
  /// Interaction logic for PersonDetailView.xaml
  /// </summary>
  public partial class PersonDetailsView : UserControl, IPersonDetailsView
  {
    public PersonDetailsView(IPersonDetailsViewModel viewModel)
    {
      InitializeComponent();

      ViewModel = viewModel;
      ViewModel.View = this;

      RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
      {
        var context = (ObservableObject<object>)s;
        var selectedPerson = (Person)context.Value;
        (ViewModel as IPersonDetailsViewModel).SelectedPerson = selectedPerson;
      };
    }

    public IViewModel ViewModel
    {
      get { return (IViewModel)DataContext; }
      set { DataContext = value; }
    }
  }
}
