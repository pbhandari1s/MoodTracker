using MoodTracker.Core.Initialize;
using MoodTracker.Web.UI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace MoodTracker.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = UnityConfig.GetConfiguredContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            var mapper = AutoMapperConfig.Initialize().CreateMapper();
            container.RegisterInstance(mapper);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected virtual void Application_End(object sender, EventArgs e)
        {
            Application.GetContainer().Dispose();
        }

        protected virtual void Application_EndRequest(object sender, EventArgs e)
        {
            foreach (var item in HttpContext.Current.Items.Values)
            {
                var disposableItem = item as IDisposable;

                disposableItem?.Dispose();
            }
        }
    }
}
