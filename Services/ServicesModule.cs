using Main.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
  public class ServicesModule : IModule
  {
    IUnityContainer _container;

    public ServicesModule(IUnityContainer container)
    {
      _container = container;
    }

    public void Initialize()
    {
      _container.RegisterType<IPersonRepository, PersonRepository>(new ContainerControlledLifetimeManager());
    }
  }
}
