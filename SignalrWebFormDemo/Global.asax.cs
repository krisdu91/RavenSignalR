using Raven.Client.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SignalrWebFormDemo
{
    public class Global : HttpApplication
    {
        public static DocumentStore store;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            store = new DocumentStore { ConnectionStringName = "RavenDB" };
            store.Initialize();
            CheckForRaven();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void CheckForRaven()
        {
            store
            .Changes()
            .ForAllDocuments()
            .Subscribe(new RavenObserver());
        }
    }
}