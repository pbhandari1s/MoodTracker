using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.CustomException
{
    public class RecordNotFoundException : System.Exception
    {
        public RecordNotFoundException() { }
        public RecordNotFoundException(string msg) : base(message: msg) { }
        public RecordNotFoundException(System.Exception ex) : base(ex.Message) { }
    }
}
