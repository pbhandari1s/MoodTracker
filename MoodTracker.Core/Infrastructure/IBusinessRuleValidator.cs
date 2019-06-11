using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public interface IBusinessRuleValidator<T> where T : IValidatable
    {
        void ThrowErrorIfInValid(T obj);
        ValidationResult IsValid(T obj);
    }
}
