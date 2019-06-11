using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public interface IAuditLog<TIdType>
    {
        DateTime CreationStamp { get; set; }
        DateTime? ModificationStamp { get; set; }

        string Addedby { get; set; }

        string ModifiedBy { get; set; }
    }
}
