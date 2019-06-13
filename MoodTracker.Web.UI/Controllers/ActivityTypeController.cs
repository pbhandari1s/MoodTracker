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
    public class ActivityTypeController : Controller
    {
        [Dependency]
        public IActivityTypeService ActivityTypeService { get; set; }

        // GET: ActivityType
        public ActionResult Index()
        {
            var activityTypes = ActivityTypeService.GetAllActive();
            return View(activityTypes);
        }

        public ActionResult Create()
        {
            var activityType = new ActivityTypeViewModel();
            return View(activityType);
        }

        [HttpPost]
        public ActionResult Create(ActivityTypeViewModel activityType)
        {
            try
            {
                ActivityTypeService.Insert(activityType);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Type Added Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error creating Activity Type" + ex.Message
                };
                return View(activityType);
            }
        }

        public ActionResult Edit(int id)
        {
            var activityType = ActivityTypeService.GetById(id);
            return View(activityType);
        }

        [HttpPost]
        public ActionResult Edit(ActivityTypeViewModel activityType)
        {
            try
            {
                ActivityTypeService.Update(activityType);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Type Updated Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error creating Activity Type " + ex.Message
                };
                return View(activityType);
            }
        }

        public ActionResult Archive(int id)
        {
            var activityType = ActivityTypeService.GetById(id);
            return View(activityType);
        }

        [HttpPost]
        public ActionResult Archive(ActivityTypeViewModel activityType)
        {
            try
            {
                ActivityTypeService.Archive(activityType.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Type archived Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error archiving Activity Type " + ex.Message
                };
                return View(activityType);
            }
        }

        public ActionResult Delete(int id)
        {
            var activityType = ActivityTypeService.GetById(id);
            return View(activityType);
        }

        [HttpPost]
        public ActionResult Delete(ActivityTypeViewModel activityType)
        {
            try
            {
                ActivityTypeService.Delete(activityType.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Type deleted Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error deleting Activity Type " + ex.Message
                };
                return View(activityType);
            }
        }

        public ActionResult Unarchive(int id)
        {
            var activityType = ActivityTypeService.GetById(id);
            return View(activityType);
        }

        [HttpPost]
        public ActionResult Unarchive(ActivityTypeViewModel activityType)
        {
            try
            {
                ActivityTypeService.Unarchive(activityType.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Type unarchived Successfully."
                };
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error unarchiving Activity Type " + ex.Message
                };
                return View(activityType);
            }
        }
    }
}