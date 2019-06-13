using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using MoodTracker.Core.Infrastructure;
using MoodTracker.Core.Initialize;
using MoodTracker.Core.Repository;
using MoodTracker.Core.UnitOfWork;
using MoodTracker.Data;
using MoodTracker.Data.Repository;
using MoodTracker.Entities.Repository;
using MoodTracker.Entities.Service;
using MoodTracker.Entities.Service.Implementation;
using MoodTracker.Web.UI.Helper;
using MoodTracker.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoodTracker.Web.UI.App_Start
{
    public class ContainerStrapper : IConfigRegistration<IUnityContainer>
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IContext, MoodTrackerDBContext>(new HttpContextLifetimeManager<IContext>());
            container.RegisterType<IUnitOfWork, EfUnitOfWork>();
            container.RegisterType<IDbAuditLogger, DbAuditLogger>();
            container.RegisterType<IAuthenticatedUser<int>, AuthenticatedUserInfo>();
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>,
            UserStore<ApplicationUser>>(new InjectionConstructor(new ApplicationDbContext()));
            container.RegisterType<IAuthenticationManager>(
            new InjectionFactory(
                o => System.Web.HttpContext.Current.GetOwinContext().Authentication
                )
            );

            container.RegisterType<IActivityTypeRepository, ActivityTypeRepository>();
            container.RegisterType<IActivityRepository, ActivityRepository>();
            container.RegisterType<IActivityLogRepository, ActivityLogRepository>();
            
            container.RegisterType<IActivityTypeService, ActivityTypeService>();
            container.RegisterType<IActivityService, ActivityService>();
            container.RegisterType<IActivityLogService, ActivityLogService>();
        }
    }
}