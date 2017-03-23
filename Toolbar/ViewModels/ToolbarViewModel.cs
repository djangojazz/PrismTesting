using Main.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbar
{
  public class ToolbarViewModel : ViewModelBase, IToolbarViewModel
  {
    public ToolbarViewModel(IToolbarView view)
        //: base(view)  // Module 7
    {

    }
  }
}
