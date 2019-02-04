using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
  public  interface IRegister
    {

        Register login(Register model);
        void register(Register user);
        IEnumerable<Register> GetAll();
    }
}
