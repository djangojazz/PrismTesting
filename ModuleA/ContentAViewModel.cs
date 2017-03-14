using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Infrastructure;

namespace ModuleA
{
  public class ContentAViewModel : IContentAViewModel
  {                      
    public IView View { get; set; }

    public ContentAViewModel(IContentAView view)
    {
      View = view;
      View.ViewModel = this;
    }
  }
}
