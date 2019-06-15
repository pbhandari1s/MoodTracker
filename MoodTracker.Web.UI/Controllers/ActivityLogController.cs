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
    public class ActivityLogController : Controller
    {
        [Dependency]
        public IActivityLogService ActivityLogService { get; set; }
        
        // GET: ActivityLog
        public ActionResult Index(int id=0)
        {
            if (id > 0)
            {
                var activityLogs = ActivityLogService.GetByActivityIdActive(id);
                var activityTitle = "";
                try
                {
                    activityTitle = activityLogs.FirstOrDefault().Activity.Title;
                }
                catch
                {

                }
                var activityLogIndex = new ActivityLogIndexViewModel()
                {
                    ActivityId = id,
                    ActivityTitle = activityTitle,
                    ActivityLogs = activityLogs
                };
                return View(activityLogIndex);
            }
            else
                return RedirectToAction("index", "activity");
        }

        public ActionResult Create(int id=0)
        {
            if(id>0)
            {
                var activityLog = new ActivityLogViewModel()
                {
                    ActivityId = id
                };
                return View(activityLog);
            }
            else
                return RedirectToAction("index", "activity");
        }

        [HttpPost]
        public ActionResult Create(ActivityLogViewModel activityLog)
        {
            try
            {
                ActivityLogService.Insert(activityLog);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Log Added Successfully."
                };
                return RedirectToAction("Index", new { id = activityLog.ActivityId});
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error adding activity log <br/>" + ex.Message
                };
                return View(activityLog);
            }
        }

        public ActionResult Edit(int id=0)
        {
            if(id>0)
            {
                var activityLog = ActivityLogService.GetById(id);

                return View(activityLog);
            }
            else
                return RedirectToAction("index", "activity");
            
        }
        
        [HttpPost]
        public ActionResult Edit(ActivityLogViewModel activityLog)
        {
            try
            {
                ActivityLogService.Update(activityLog);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Log updated Successfully."
                };
                return RedirectToAction("Index", new { id = activityLog.ActivityId});
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error adding activity log <br/>" + ex.Message
                };
                return View(activityLog);
            }
        }

        public ActionResult Archive(int id=0)
        {
            if(id>0)
            {
                var activityLog = ActivityLogService.GetById(id);
                return View(activityLog);
            }
            else
                return RedirectToAction("index", "activity");
        }

        [HttpPost]
        public ActionResult Archive(ActivityLogViewModel activityLog)
        {
            try
            {
                ActivityLogService.Archive(activityLog.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Log archived Successfully."
                };
                return RedirectToAction("Index", new { id = activityLog.ActivityId });
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error archiving Activity Log " + ex.Message
                };
                return View(activityLog);
            }
        }

        public ActionResult Delete(int id=0)
        {
            if(id>0)
            {
                var activityLog = ActivityLogService.GetById(id);
                return View(activityLog);
            }
            else
                return RedirectToAction("index", "activity");
        }

        [HttpPost]
        public ActionResult Delete(ActivityLogViewModel activityLog)
        {
            try
            {
                ActivityLogService.Delete(activityLog.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Log deleted Successfully."
                };
                return RedirectToAction("Index", new { id = activityLog.ActivityId });
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error deleting Activity Log " + ex.Message
                };
                return View(activityLog);
            }
        }

        public ActionResult Unarchive(int id=0)
        {
            if(id>0)
            {
                var activityLog = ActivityLogService.GetById(id);
                return View(activityLog);
            }
            else
                return RedirectToAction("index", "activity");
        }

        [HttpPost]
        public ActionResult Unarchive(ActivityLogViewModel activityLog)
        {
            try
            {
                ActivityLogService.Unarchive(activityLog.Id);
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Success,
                    Message = "Activity Log unarchived successfully."
                };
                return RedirectToAction("Index", new { id = activityLog.ActivityId });
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = new CRUDNotification()
                {
                    NotificationType = CRUDNotification.NotificationTypes.Error,
                    Message = "Error unarchiving Activity Log " + ex.Message
                };
                return View(activityLog);
            }
        }
    }
}