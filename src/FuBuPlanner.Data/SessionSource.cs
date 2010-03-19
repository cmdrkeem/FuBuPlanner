using System.IO;
using System.Web;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.TA;

namespace FuBuPlanner.Data
{
    public static class SessionSource 
    {
        private static IObjectServer _server;

        public static ISession CreateUnitOfWork()
        {
            EnsureServer();
            return new Db4oSession(_server);
        }

        private static void EnsureServer()
        {
            if (_server == null)
            {
                var dbPath = System.Configuration.ConfigurationManager
                    .ConnectionStrings["ObjectStore"].ConnectionString;

                if (dbPath.Contains("|DataDirectory|"))
                {
                    dbPath = dbPath.Replace("|DataDirectory|", "");
                    var appDir = HttpContext.Current.Server.MapPath("~/App_Data/");
                    dbPath = Path.Combine(appDir, dbPath);
                }

                var configuration = Db4oClientServer.NewServerConfiguration();
                configuration.Common.Add(new TransparentPersistenceSupport());
                configuration.Common.Add(new TransparentActivationSupport());
                _server = Db4oClientServer.OpenServer(configuration, dbPath, 0);
            }
        }
    }
}