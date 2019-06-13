using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Domain
{
    public class Activity : EntityBase<int>, IAggregateRoot
    {
        public int ActivityTypeId { get; set; }
        public string Title { get; set; }
        public string CourseInfo { get; set; }
        public DateTime DueDate { get; set; }
        public string GradeWorth { get; set; }
        public int InitialMood { get; set; }
        public virtual ActivityType ActivityType { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}
