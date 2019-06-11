using MoodTracker.Core.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public abstract class BusinessRuleValidationBase<T> where T : IValidatable
    {

        private readonly List<BusinessRule> _brokenRules;

        protected BusinessRuleValidationBase()
        {
            _brokenRules = new List<BusinessRule>();
        }

        protected abstract void Validate(T obj);

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public void ThrowErrorIfInValid(T obj)
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (BusinessRule br in ValidationErrors(obj))
            {
                counter += 1;
                sb.AppendLine(string.Format("{0}) {1}", counter.ToString(), br.RuleDescription));
            }

            if (counter > 0)
                throw new BusinessRuleException(sb.ToString());
        }

        protected IEnumerable<BusinessRule> ValidationErrors(T obj)
        {
            _brokenRules.Clear();
            Validate(obj);
            return _brokenRules;
        }

        public ValidationResult IsValid(T obj)
        {
            return new ValidationResult() { IsValid = _brokenRules.Count > 0, Errors = ValidationErrors(obj) };
        }
    }
}
