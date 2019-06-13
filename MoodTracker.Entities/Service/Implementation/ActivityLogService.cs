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
    public class ActivityLogService : IActivityLogService
    {
        protected readonly IActivityLogRepository Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public ActivityLogService(IActivityLogRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Archive(int activityLogId)
        {
            Repository.Archive(activityLogId);
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<ActivityLogViewModel> GetByActivityId(int activityId)
        {
            var result = Repository.GetByActivityId(activityId);

            return Mapper.Map<IEnumerable<ActivityLogViewModel>>(result);
        }

        public IEnumerable<ActivityLogViewModel> GetByActivityIdActive(int activityId)
        {
            var result = Repository.GetByActivityId(activityId);

            return Mapper.Map<IEnumerable<ActivityLogViewModel>>(result);
        }

        public ActivityLogViewModel GetById(int activityLogId)
        {
            var result = Repository.GetById(activityLogId);

            return Mapper.Map<ActivityLogViewModel>(result);
        }

        public void Insert(ActivityLogViewModel activityLog)
        {
            var activityLogInfo = new ActivityLog()
            {
               ActivityId = activityLog.ActivityId,
               Mood = activityLog.Mood,
               Note=activityLog.Note
            };

            Repository.Insert(activityLogInfo);

            UnitOfWork.SaveChanges();
        }

        public void Delete(int activityLogId)
        {
            Repository.Delete(activityLogId);
            UnitOfWork.SaveChanges();
        }

        public void Unarchive(int activityLogId)
        {
            Repository.Unarchive(activityLogId);
            UnitOfWork.SaveChanges();
        }

        public void Update(ActivityLogViewModel activityLogInfo)
        {
            var activityLog = Repository.GetById(activityLogInfo.Id);
            activityLog.ActivityId = activityLogInfo.ActivityId;
            activityLog.Mood = activityLogInfo.Mood;
            activityLog.Note = activityLogInfo.Note;
            activityLog.IsArchived = activityLogInfo.IsArchived;

            Repository.Update(activityLog);

            UnitOfWork.SaveChanges();
        }
    }
}
