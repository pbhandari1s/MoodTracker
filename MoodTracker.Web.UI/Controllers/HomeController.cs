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
            IEnumerable<ActivityDashboardViewModel> recentActivity = new List<ActivityDashboardViewModel>();
            if(User.Identity.IsAuthenticated)
            {
                recentActivity = ActivityService.GetDashboardInfo();
            } 
            return View(recentActivity);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}