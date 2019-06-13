using MoodTracker.Core.Repository;
using MoodTracker.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Repository
{
    public interface IActivityLogRepository : IRepository<ActivityLog, int>
    {
        IEnumerable<ActivityLog> GetByActivityId(int activityId);
        IEnumerable<ActivityLog> GetByActivityIdActive(int activityId);
    }
}
