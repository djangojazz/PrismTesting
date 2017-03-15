﻿using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Main.Infrastructure;

namespace People
{
  public class PeopleModule : IModule
  {
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _container;

    public PeopleModule(IUnityContainer container, IRegionManager regionManager)
    {
      this._container = container;
      this._regionManager = regionManager;
    }

    public void Initialize()
    {
      RegisterViewsAndServices();

      var vm = this._container.Resolve<IPersonViewModel>();
      _regionManager.Regions[RegionNames.ContentRegion].Add(vm.View);
    }

    protected void RegisterViewsAndServices()
    {
      _container.RegisterType<IPersonViewModel, PersonViewModel>();
      _container.RegisterType<IPersonView, PersonView>();
    }
  }
}
