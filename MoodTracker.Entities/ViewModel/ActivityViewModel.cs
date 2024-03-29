﻿using MoodTracker.Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.ViewModel
{
    public class ActivityViewModel : IViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "* Activity Type is required.", AllowEmptyStrings = false)]
        public int ActivityTypeId { get; set; }
        [Required(ErrorMessage = "* Title is required.", AllowEmptyStrings = false)]
        public string Title { get; set; }
        public string CourseInfo { get; set; }
        [Required(ErrorMessage = "* Due Date is required.", AllowEmptyStrings = false)]
        public DateTime DueDate { get; set; }
        public string GradeWorth { get; set; }
        [Required(ErrorMessage = "* Initial Mood is required.", AllowEmptyStrings = false)]
        public int InitialMood { get; set; }
        public bool IsArchived { get; set; }
        public virtual ActivityTypeViewModel ActivityType { get; set; }
        public virtual ICollection<ActivityLogViewModel> ActivityLogs { get; set; }
        public ActivityViewModel()
        {
            ActivityLogs = new List<ActivityLogViewModel>();
        }
    }

    public class ActivityDashboardViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class ActivityBasicInfoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
}
