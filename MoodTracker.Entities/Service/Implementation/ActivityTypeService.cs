using AutoMapper;
using MoodTracker.Core.UnitOfWork;
using MoodTracker.Entities.Domain;
using MoodTracker.Entities.Repository;
using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Service.Implementation
{
    public class ActivityTypeService : BaseFilterService<ActivityType, ActivityTypeViewModel, int>, IActivityTypeService
    {
        public ActivityTypeService(IActivityTypeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {

        }

        public void Insert(ActivityTypeViewModel activityType)
        {
            var activityTypeInfo = new ActivityType()
            {
                Type = activityType.Type
            };

            if (activityTypeInfo.Id > 0)
                Repository.Update(activityTypeInfo);
            else
                Repository.Insert(activityTypeInfo);

            UnitOfWork.SaveChanges();
        }

        public void Update(ActivityTypeViewModel activityType)
        {
            var currentActivityType = Repository.GetById(activityType.Id);
            currentActivityType.Type = activityType.Type;
            currentActivityType.IsArchived = activityType.IsArchived;

            Repository.Update(currentActivityType);
            UnitOfWork.SaveChanges();
        }
    }
}
