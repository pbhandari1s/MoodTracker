using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.CustomException
{
    public class Contract
    {
        public static void Requires<TException>(bool predicate, string message = "")
        where TException : Exception, new()
        {
            if (!predicate)
            {
                throw new TException();
            }
        }
    }
}
