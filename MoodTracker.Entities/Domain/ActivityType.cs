using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Domain
{
    public class ActivityType : EntityBase<int>, IAggregateRoot
    {
        public string Type { get; set; }
    }
}
