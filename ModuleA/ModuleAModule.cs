﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Regions;
using Main.Infrastructure;
using Microsoft.Practices.Prism.MefExtensions.Modularity;

namespace ModuleA
{
  ////1. Code method of doing Prism: Setting OnDemand to true will delay automatic startup
  //[Module(ModuleName = "ModuleA", OnDemand = true)]

  ////5. MEF way of doing Prism, need the MEF extensions and System.ComponentModel.Composition
  //[ModuleExport(typeof(ModuleAModule), InitializationMode=InitializationMode.WhenAvailable)]

  //[Module(ModuleName = "ModuleA", OnDemand = true)]
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
      _container.RegisterType<ToolbarA>();
      _container.RegisterType<IContentAView, ContentA>();
      _container.RegisterType<IContentAViewModel, ContentAViewModel>();
                                                     
      ////experiment with regions here
      //IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
                                                                             
      _regionManager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(ToolbarA));
    }
  }
}
