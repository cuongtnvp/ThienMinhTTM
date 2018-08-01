using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Data.Interfaces
{
   public interface IHasSoftDelete
    {
        bool IDeleted { set; get; }

    }
}
