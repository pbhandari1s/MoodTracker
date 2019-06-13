using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Service
{
    public interface IActivityLogService
    {
        void Insert(ActivityLogViewModel activityLogInfo);
        void Update(ActivityLogViewModel activityLogInfo);
        void Archive(int activityLogId);
        void Delete(int activityLogId);
        void Unarchive(int activityLogId);
        ActivityLogViewModel GetById(int activityLogId);
        IEnumerable<ActivityLogViewModel> GetByActivityId(int activityId);
        IEnumerable<ActivityLogViewModel> GetByActivityIdActive(int activityId);
    }
}
