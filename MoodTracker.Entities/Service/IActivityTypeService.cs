using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Service
{
    public interface IActivityTypeService
    {
        IEnumerable<ActivityTypeViewModel> GetAll();
        IEnumerable<ActivityTypeViewModel> GetAllActive();
        IEnumerable<ActivityTypeViewModel> GetArchived();
        void Insert(ActivityTypeViewModel activityType);
        void Update(ActivityTypeViewModel activityType);
        void Archive(int id);
        void Unarchive(int id);
        void Delete(int id);
        ActivityTypeViewModel GetById(int id);
    }
}
