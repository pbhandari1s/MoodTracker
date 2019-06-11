using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<BusinessRule> Errors { get; set; }
    }
}
