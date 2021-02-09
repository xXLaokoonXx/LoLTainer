﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLTainer.Interfaces
{
    public interface IAppInformationProvider
    {
        ILCUAPIInformationProvider LCUAPIInformationProvider { get; }
        IIngameAPIInformationProvider IngameAPIInformationProvider { get; }
    }
}
