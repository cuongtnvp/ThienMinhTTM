﻿using ERPCartonWeb.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERPCartonWeb.Data.Interfaces
{
   public interface ISwitchable
    {
        Status Status { set; get; }
    }
}
