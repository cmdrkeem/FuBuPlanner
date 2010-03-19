using System;
using System.Web;
using System.Web.Routing;

namespace FuBuPlanner.Web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var routeCollection = RouteTable.Routes;
            FubuStructureMapBootstrapper.Bootstrap(routeCollection);
        }
    }
}