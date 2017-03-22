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
using Microsoft.Practices.Prism.MefExtensions;
using System.ComponentModel.Composition.Hosting;
using People;
using StatusBar;
using Toolbar;
using Services;
using Services.PersonService;
using ModuleB;

namespace Main
{
  public class Bootstrapper : UnityBootstrapper
  //MefBootstrapper 
  //UnityBootstrapper Unity is the standard for the most part
  {
    protected override DependencyObject CreateShell()
    {
      //Unity Way
      return Container.Resolve<Shell>();

      ////MEF way
      //return Container.GetExportedValue<Shell>();
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();                               
      App.Current.MainWindow = (Window)Shell;
      App.Current.MainWindow.Show();
    }

    protected override void ConfigureContainer()
    {
      base.ConfigureContainer();
      Container.RegisterType<IShellViewModel, ShellViewModel>();
    }

    protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
    {
      RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
      mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
      return mappings;
    }

    protected override IModuleCatalog CreateModuleCatalog()
    {
      ModuleCatalog catalog = new ModuleCatalog();

      catalog.AddModule(typeof(ModuleAModule));
      catalog.AddModule(typeof(ModuleBModule));

      //catalog.AddModule(typeof(ServicesModule));
      //catalog.AddModule(typeof(ToolbarModule));
      //catalog.AddModule(typeof(PeopleModule));
      //catalog.AddModule(typeof(StatusBarModule));

      //catalog.AddModule(typeof(PersonServiceModule));
      //catalog.AddModule(typeof(ModuleAModule));

      return catalog;
    }

    //protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
    //{
    //  RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
    //  //Unity way
    //  mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());

    //  ////Mef way
    //  //mappings.RegisterMapping(typeof(StackPanel), Container.GetExportedValue<StackPanelRegionAdapter>());
    //  return mappings;
    //}

    ////1. Code method of doing Prism
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

    ////2. Directory method of doing Prism, you need to build the dll manually and create a directory called 'Modules' in the bin folder and then run that.
    //protected override IModuleCatalog CreateModuleCatalog()
    //{
    //  return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };

    //}

    ////3. Load from a xaml resource dictionary
    //protected override IModuleCatalog CreateModuleCatalog()
    //{
    //  return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
    //    new Uri("/Main;component/XamlCatalog.xaml", UriKind.Relative));

    //}

    //  //4. Load from config file
    //protected override IModuleCatalog CreateModuleCatalog()
    //{
    //  return new ConfigurationModuleCatalog();
    //}

    ////5. Load from MEF method
    //protected override void ConfigureAggregateCatalog()
    //{
    //  base.ConfigureAggregateCatalog();
    //  AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
    //  AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StackPanelRegionAdapter).Assembly));
    //  AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleAModule).Assembly));
    //}
  }
}
