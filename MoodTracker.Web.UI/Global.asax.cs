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
using MoodTracker.Core.CustomException;

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

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError().GetBaseException();

            HttpException httpException = exception as HttpException;
            RecordNotFoundException recordException = exception as RecordNotFoundException;

            if (httpException != null)
            {
                Server.ClearError();
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        {
                            Response.Redirect("~/home/error?id=404");
                        }
                        break;

                    default:
                        {   
                            Response.Redirect("~/home/error/");
                        }
                        break;
                }
            }
            else if(recordException != null)
            {
                Response.Redirect("~/home/error?id=204");
            }
            else
            {
                Response.Redirect("~/home/error/");
            }
        }
    }
}
