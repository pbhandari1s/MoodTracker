using AutoMapper;
using MoodTracker.Entities.Domain;
using MoodTracker.Entities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities
{
    public class EntitiesMapProfile : Profile
    {
        public EntitiesMapProfile()
        {
            CreateMap<ActivityType, ActivityTypeViewModel>();
            CreateMap<Activity, ActivityViewModel>();
            CreateMap<ActivityLog, ActivityLogViewModel>();
            CreateMap<Activity, ActivityDashboardViewModel>();
            CreateMap<Activity, ActivityBasicInfoViewModel>();
        }
    }

}
