using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using ModuleA;

namespace Main
{
  public class Bootstrapper : UnityBootstrapper
  {
    protected override DependencyObject CreateShell()
    {
      return Container.Resolve<Shell>();
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();

      App.Current.MainWindow = (Window)Shell;
      App.Current.MainWindow.Show();
    }

    protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
    {
      ModuleCatalog catalog = new ModuleCatalog();
      catalog.AddModule(typeof(ModuleAModule));
      return catalog;
    }
  }
}
