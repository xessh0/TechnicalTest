using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public class NameSpecification : ISpecification<Window>
    {
        private string _name;
        public NameSpecification(string name) => _name = name;
        public bool IsSatisfiedBy(Window entity) => entity.Name == _name;
    }

    public class NameLackSpecification : ISpecification<Window>
    {
        public bool IsSatisfiedBy(Window entity) => entity.Name != String.Empty;
    }

    public class VisibilitySpecification : ISpecification<Window>
    {
        public bool IsSatisfiedBy(Window entity) => entity.IsVisible == true;
    }

    public class SizeSpecification : ISpecification<Window>
    {
        public bool IsSatisfiedBy(Window entity) => entity.Width != 0 && entity.Height != 0;
    }
}
