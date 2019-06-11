using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.CustomException
{
    class ValueObjectInvalidException : System.Exception
    {
        public ValueObjectInvalidException(string message)
            : base(message)
        {
        }
    }
}
