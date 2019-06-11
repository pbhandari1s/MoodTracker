using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.CustomException
{
    public class BusinessRuleException : System.Exception
    {
        public BusinessRuleException() { }
        public BusinessRuleException(string msg) : base(msg) { }
        public BusinessRuleException(System.Exception ex) : base(ex.Message) { }
    }
}
