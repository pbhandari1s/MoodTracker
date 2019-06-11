using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MoodTracker.Core.Initialize
{
    public static class HttpApplicationStateExtension
    {
        private const string GlobalContainerKey = "GlobalUnityContainerKey";

        public static IUnityContainer GetContainer(this HttpApplicationState application)
        {
            application.Lock();
            try
            {
                IUnityContainer container = application[GlobalContainerKey] as IUnityContainer;
                if (container == null)
                {
                    container = new UnityContainer();
                    application[GlobalContainerKey] = container;
                }
                return container;
            }
            finally
            {
                application.UnLock();
            }
        }
    }
}
