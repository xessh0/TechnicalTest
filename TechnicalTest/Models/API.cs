using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTest.Models
{
    public class API
    {
        static API()
        {
            API.Init();
        }

        static IContainer _container;

        public static void Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Window.WinApiFetcher>().As<Window.IFetcher>();
            builder.RegisterType<Window.Filter>().As<Window.IFilter>();
            _container = builder.Build();
        }

        public IReadOnlyList<Window.Window> GetWindows()
        {
            var fetcher = _container.Resolve<Window.IFetcher>();
            var filter = _container.Resolve<Window.IFilter>();
            var repository = new Window.Repository(fetcher, filter);

            return repository.GetAll();
        }

        public Window.Window GetWindowByName(string name)
        {
            var fetcher = _container.Resolve<Window.IFetcher>();
            var filter = _container.Resolve<Window.IFilter>();
            var repository = new Window.Repository(fetcher, filter);

            return repository.FindByName(name);
        }
    }
}
