using System;
using System.Web.Routing;
using Db4objects.Db4o;
using FubuMVC.Core.Runtime;
using FubuMVC.StructureMap;
using FuBuPlanner.Data;
using FuBuPlanner.Web.Behaviours;
using StructureMap;

namespace FuBuPlanner.Web
{
    public class FubuStructureMapBootstrapper : IBootstrapper
    {
        private readonly RouteCollection _routes;

        private FubuStructureMapBootstrapper(RouteCollection routes)
        {
            _routes = routes;
        }

        public void BootstrapStructureMap()
        {
            UrlContext.Reset();

            ObjectFactory.Initialize(x =>
                                         {
                                             x.ForSingletonOf<SessionSource>().Use<SessionSource>();
                                             x.For<IRepository>().Use(ctx=>ctx.GetInstance<SessionSource>().CreateSession());
                                         });

            BootstrapFubu(ObjectFactory.Container, _routes);
        }

        private static void BootstrapFubu(IContainer container, RouteCollection routes)
        {
            var bootstrapper = new StructureMapBootstrapper(container, new FuBuPlannerRegistry())
                                   {
                                       Builder = (c, args, id) => new RepositoryBehaviour(c, args, id)
                                   };
            bootstrapper.Bootstrap(routes);
        }

        public static void Bootstrap(RouteCollection routes)
        {
            new FubuStructureMapBootstrapper(routes).BootstrapStructureMap();
        }
    }
}