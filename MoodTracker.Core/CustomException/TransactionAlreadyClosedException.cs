using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.CustomException
{
    public class TransactionAlreadyClosedException : Exception
    {
        public TransactionAlreadyClosedException() { }
        public TransactionAlreadyClosedException(string msg) : base(message: msg) { }
        public TransactionAlreadyClosedException(System.Exception ex) : base(ex.Message) { }
    }
}
