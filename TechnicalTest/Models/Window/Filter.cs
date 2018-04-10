using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public class Filter : IFilter
    {
        public bool IsSatisfied(Window window)
        {
            var nameLack = new NameLackSpecification();
            var visibility = new VisibilitySpecification();
            var size = new SizeSpecification();

            var filter = nameLack.And(visibility).And(size);

            return filter.IsSatisfiedBy(window);
        }

        public bool IsSatisfiedWithName(Window window, string name)
        {
            var nameSpec = new NameSpecification(name);

            return IsSatisfied(window) && nameSpec.IsSatisfiedBy(window);
        }
    }
}
