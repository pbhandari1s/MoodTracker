using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Service
{
    public interface IActivityService
    {
        int Insert(ActivityViewModel activityInfo);
        void Update(ActivityViewModel activityInfo);
        void Archive(int activityId);
        void Delete(int activityId);
        void Unarchive(int activityId);
        ActivityViewModel GetById(int activityId);
        ActivityBasicInfoViewModel GetByIdBasicInfo(int activityId);
        IEnumerable<ActivityDashboardViewModel> GetDashboardInfo();
    }
}
