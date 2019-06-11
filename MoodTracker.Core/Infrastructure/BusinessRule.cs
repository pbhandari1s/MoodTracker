using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public class BusinessRule
    {
        private readonly string _ruleDescription;

        public BusinessRule(string ruleDescription)
        {
            _ruleDescription = ruleDescription;
        }

        public string RuleDescription
        {
            get
            {
                return _ruleDescription;
            }
        }
    }
}
