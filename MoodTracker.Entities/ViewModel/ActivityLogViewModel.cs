using MoodTracker.Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.ViewModel
{
    public class ActivityLogViewModel : IViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int ActivityId { get; set; }
        public int Mood { get; set; }
        public string Note { get; set; }

        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
        public virtual ActivityViewModel Activity { get; set; }
    }
}
