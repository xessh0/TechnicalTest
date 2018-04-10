using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public interface IFilter
    {
        bool IsSatisfied(Window window);
        bool IsSatisfiedWithName(Window window, string name);
    }
}
