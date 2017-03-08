﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Main.Infrastructure;

namespace ModuleA
{
  //Setting OnDemand to true will delay automatic startup
  [Module(ModuleName = "ModuleA", OnDemand =true)]
  public class ModuleAModule : IModule
  {
    IUnityContainer _container;
    IRegionManager _regionManager;

    public ModuleAModule(IUnityContainer container, IRegionManager regionManager)
    {
      _container = container;
      _regionManager = regionManager;
    }

    public void Initialize()
    {
      //experiment with regions here
      IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];

      region.Add(_container.Resolve<ToolbarView>());
      region.Add(_container.Resolve<ToolbarView>());
      region.Add(_container.Resolve<ToolbarView>());
      region.Add(_container.Resolve<ToolbarView>());
      region.Add(_container.Resolve<ToolbarView>());

      _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
    }
  }
}
