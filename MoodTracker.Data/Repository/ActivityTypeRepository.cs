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
    public class ActivityTypeRepository : Repository<ActivityType, int>, IActivityTypeRepository
    {
        private readonly IAuthenticatedUser<int> _authenticatedUsers;
       
        public ActivityTypeRepository(IContext context) : base(context)
        {
        }

        public override IEnumerable<ActivityType> GetAll()
        {
            return base.Get(x=>x.Addedby == _authenticatedUsers.Id, x => x.OrderBy(a => a.Type));
        }
    }
}
