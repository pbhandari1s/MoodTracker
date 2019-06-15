using MoodTracker.Core.Infrastructure;
using MoodTracker.Core.Repository;
using MoodTracker.Core.UnitOfWork;
using MoodTracker.Entities.Domain;
using MoodTracker.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data.Repository
{
    public class ActivityLogRepository : Repository<ActivityLog, int>, IActivityLogRepository
    {
        public ActivityLogRepository(IContext context, IAuthenticatedUser<int> authenticatedUser) : base(context, authenticatedUser)
        {

        }

        public IEnumerable<ActivityLog> GetByActivityId(int activityId)
        {
            return base.Get(x=>x.ActivityId == activityId, x => x.OrderBy(o => o.CreationStamp));
        }

        public IEnumerable<ActivityLog> GetByActivityIdActive(int activityId)
        {
            return base.Get(x => x.ActivityId == activityId && x.IsArchived==false, x => x.OrderBy(o => o.CreationStamp));
        }
    }
}
