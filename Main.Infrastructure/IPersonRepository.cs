﻿using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Infrastructure
{
  public interface IPersonRepository
  {
    int SavePerson(Person person);
  }
}
