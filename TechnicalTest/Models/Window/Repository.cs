using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models.Window
{
    public class Repository
    {
        IFetcher _fetcher;
        IFilter _filter;

        public Repository(IFetcher fetcher, IFilter filter)
        {
            _fetcher = fetcher;
            _filter = filter;
        }

        public IReadOnlyList<Window> GetAll()
        {
            return _fetcher.FetchAll().Where(x => _filter.IsSatisfied(x)).ToList();
        }

        public Window FindByName(string name)
        {
            return _fetcher.FetchAll().Where(x => _filter.IsSatisfiedWithName(x, name)).FirstOrDefault();
        }
    }
}
