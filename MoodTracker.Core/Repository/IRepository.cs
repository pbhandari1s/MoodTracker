using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>, ICUDRepository<T, TId> where T : IEntity<TId>
    {

    }
}
