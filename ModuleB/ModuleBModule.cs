using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Main.Infrastructure;

namespace ModuleB
{
  public class ModuleBModule : ModuleBase
  {
    public ModuleBModule(IUnityContainer container, IRegionManager regionManager)
        : base(container, regionManager) { }

    protected override void InitializeModule()
    {
      RegionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ViewBButton));
    }

    protected override void RegisterTypes()
    {          
      //Doesn't work                      
      //Container.RegisterType<ViewB>();
      //Works but long                    
      //Container.RegisterType<object, ViewB>(typeof(ViewB).FullName);
      //Custom ExtensionMethod Makes it easier
      Container.RegisterTypeForNavigation<ViewB>();
    }
  }
}
