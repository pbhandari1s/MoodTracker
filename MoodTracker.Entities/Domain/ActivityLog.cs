using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Domain
{
    public class ActivityLog : EntityBase<int>, IAggregateRoot
    {
        public int ActivityId { get; set; }
        public int Mood { get; set; }
        public string Note { get; set; }
        public virtual Activity Activity { get; set; }
    }
}
