using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Main.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
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

    

    protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
    {
      RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
      mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
      return mappings;
    }

    ////Chapter Before method
    //protected override IModuleCatalog CreateModuleCatalog()
    //{
    //  ModuleCatalog catalog = new ModuleCatalog();
    //  catalog.AddModule(typeof(ModuleAModule));
    //  return catalog;
    //}

    ////Code method of doing Prism
    //protected override void ConfigureModuleCatalog()
    //{
    //  Type moduleAType = typeof(ModuleAModule);
    //  ModuleCatalog.AddModule(new ModuleInfo()
    //  {
    //    ModuleName = moduleAType.Name,
    //    ModuleType = moduleAType.AssemblyQualifiedName,
    //    InitializationMode = InitializationMode.WhenAvailable
    //  });
    //}

    //Directory method of doing Prism, you need to build the dll manually and create a directory called 'Modules' in the bin folder and then run that.
    protected override IModuleCatalog CreateModuleCatalog()
    {
      return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };

    }
  }
}
