using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Initialize
{
    public interface IConfigRegistration<T>
    {
        void Register(T item);
    }
}
