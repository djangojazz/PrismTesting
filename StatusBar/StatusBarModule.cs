﻿using Main.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBar
{
  public class StatusBarModule : IModule
  {
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _container;

    public StatusBarModule(IUnityContainer container, IRegionManager regionManager)
    {
      this._container = container;
      this._regionManager = regionManager;
    }

    public void Initialize()
    {
      RegisterViewsAndServices();

      var vm = _container.Resolve<IStatusBarViewModel>();
      ////Works with Module5
      //_regionManager.Regions[RegionNames.StatusBarRegion].Add(vm.View);
    }

    protected void RegisterViewsAndServices()
    {
      _container.RegisterType<IStatusBarViewModel, StatusBarViewModel>();
      _container.RegisterType<IStatusBarView, StatusBarView>();
    }
  }
}
