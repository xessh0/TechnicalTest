﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public interface IFetcher
    {
        IReadOnlyList<Window> FetchAll();
    }
}
