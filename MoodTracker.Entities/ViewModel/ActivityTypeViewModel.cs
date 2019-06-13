using MoodTracker.Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.ViewModel
{
    public class ActivityTypeViewModel : IViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Required", AllowEmptyStrings = false)]
        public string Type { get; set; }
        [ScaffoldColumn(false)]
        public bool IsArchived { get; set; }
    }
}
