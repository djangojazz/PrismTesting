﻿using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Infrastructure
{
  public class ApplicationCommands
  {
    public static CompositeCommand NavigateCommand = new CompositeCommand();
  }
}
