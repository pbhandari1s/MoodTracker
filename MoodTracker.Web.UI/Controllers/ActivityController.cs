using Microsoft.Practices.Unity;
using MoodTracker.Core.Helper;
using MoodTracker.Entities.Service;
using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoodTracker.Web.UI.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        [Dependency]
        public IActivityService ActivityService { get; set; }

        [Dependency]
        public IActivityTypeService ActivityTypeService { get; set; }

        // GET: Activity
        public ActionResult Index()
        {
            var activities = ActivityService.GetDashboardInfo();
            return View(activities);
        }

        public ActionResult Create()
        {
            var activity = new ActivityViewModel() {
                DueDate = DateTime.Now
            };
            var activityTypes = ActivityTypeService.GetAllActive();
            ViewBag.ActivityTypes = new SelectList(activityTypes, "Id", "Type");
            return View(activity);
        }

        [HttpPost]
        public ActionResult Create(ActivityViewModel activity)
        {
            try
            {
                ActivityService.Insert(activity);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Added Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error creating Activity " + ex.Message
                };
                return View(activity);
            }
        }

        public ActionResult Edit(int id)
        {
            var activity = ActivityService.GetById(id);
            var activityTypes = ActivityTypeService.GetAllActive();
            ViewBag.ActivityTypes = new SelectList(activityTypes, "Id", "Type");
            return View(activity);
        }

        [HttpPost]
        public ActionResult Edit(ActivityViewModel activity)
        {
            try
            {
                ActivityService.Update(activity);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Updated Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error updating Activity " + ex.Message
                };
                return View(activity);
            }
        }

        public ActionResult Archive(int id)
        {
            var activity = ActivityService.GetByIdBasicInfo(id);
            return View(activity);
        }

        [HttpPost]
        public ActionResult Archive(ActivityBasicInfoViewModel activity)
        {
            try
            {
                ActivityService.Archive(activity.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity archived Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error archiving activity " + ex.Message
                };
                return View(activity);
            }
        }

        public ActionResult Delete (int id)
        {
            var activity = ActivityService.GetByIdBasicInfo(id);
            return View(activity);
        }

        [HttpPost]
        public ActionResult Delete(ActivityBasicInfoViewModel activity)
        {
            try
            {
                ActivityService.Delete(activity.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity deleted Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error deleting activity " + ex.Message
                };
                return View(activity);
            }
        }

        public ActionResult Unarchive(int id)
        {
            var activity = ActivityService.GetByIdBasicInfo(id);
            return View(activity);
        }

        [HttpPost]
        public ActionResult Unarchive(ActivityBasicInfoViewModel activity)
        {
            try
            {
                ActivityService.Unarchive(activity.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity unarchived successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error unarchiving activity " + ex.Message
                };
                return View(activity);
            }
        }

        public ActionResult Detail(int id=0)
        {
            if (id > 0)
            {
                var activityDetail = ActivityService.GetById(id);

                return View(activityDetail);
            }
            else
                return RedirectToAction("index", "activity");
        }
    }
}