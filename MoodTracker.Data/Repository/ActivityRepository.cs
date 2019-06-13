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
    public class ActivityRepository : Repository<Activity, int>, IActivityRepository
    {
        public ActivityRepository(IContext context) : base(context)
        {

        }

        public IEnumerable<Activity> GetRecent()
        {
            return base.Get(x => x.IsArchived == false, o => o.OrderBy(a => a.DueDate)).Take(8);
        }
    }
}
