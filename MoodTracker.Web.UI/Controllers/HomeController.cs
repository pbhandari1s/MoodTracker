using Microsoft.Practices.Unity;
using MoodTracker.Entities.Service;
using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoodTracker.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IActivityService ActivityService { get; set; }
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                IEnumerable<ActivityDashboardViewModel> recentActivity = new List<ActivityDashboardViewModel>();
                if (User.Identity.IsAuthenticated)
                {
                    recentActivity = ActivityService.GetDashboardInfo();
                }
                return View(recentActivity);
            }
            else
            {
                return RedirectToAction("login", "account");
            }
           
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}