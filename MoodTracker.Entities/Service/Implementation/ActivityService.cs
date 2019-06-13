using AutoMapper;
using MoodTracker.Core.CustomException;
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
    public class ActivityService : IActivityService
    {
        protected readonly IActivityRepository Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        public ActivityService(IActivityRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public void Archive(int activityId)
        {
            Repository.Archive(activityId);
            UnitOfWork.SaveChanges();
        }

        public ActivityViewModel GetById(int activityId)
        {
            var item = Repository.GetById(activityId);

            if (item == null)
                throw new RecordNotFoundException();

            return Mapper.Map<ActivityViewModel>(item);
        }

        public ActivityBasicInfoViewModel GetByIdBasicInfo(int activityId)
        {
            var item = Repository.GetById(activityId);

            if (item == null)
                throw new RecordNotFoundException();

            return Mapper.Map<ActivityBasicInfoViewModel>(item);
        }

        public IEnumerable<ActivityDashboardViewModel> GetDashboardInfo()
        {
            var item = Repository.GetRecent();

            if (item == null)
                throw new RecordNotFoundException();

            return Mapper.Map<IEnumerable<ActivityDashboardViewModel>>(item);
        }

        public void Delete(int activityId)
        {
            Repository.Delete(activityId);
            UnitOfWork.SaveChanges();
        }

        public void Unarchive(int activityId)
        {
            Repository.Delete(activityId);
            UnitOfWork.SaveChanges();
        }

        public void Update(ActivityViewModel activityInfo)
        {
            var activity = Repository.GetById(activityInfo.Id);
            activity.ActivityTypeId = activityInfo.ActivityTypeId;
            activity.Title = activityInfo.Title;
            activity.CourseInfo = activityInfo.CourseInfo;
            activity.DueDate = activityInfo.DueDate;
            activity.GradeWorth = activityInfo.GradeWorth;
            activity.InitialMood = activityInfo.InitialMood;
            activity.IsArchived = activityInfo.IsArchived;

            Repository.Update(activity);

            UnitOfWork.SaveChanges();
        }

        public int Insert(ActivityViewModel activityInfo)
        {
            var activity = new Activity()
            {
                ActivityTypeId= activityInfo.ActivityTypeId,
                Title = activityInfo.Title,
                CourseInfo = activityInfo.CourseInfo,
                DueDate =activityInfo.DueDate,
                GradeWorth = activityInfo.GradeWorth,
                InitialMood = activityInfo.InitialMood
            };

            Repository.Insert(activity);

            UnitOfWork.SaveChanges();

            return activity.Id;
        }
    }
}
