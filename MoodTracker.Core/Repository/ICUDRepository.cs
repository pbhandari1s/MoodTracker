using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public interface ICUDRepository<T, TId> where T : IEntity<TId>
    {
        void Insert(T entity);
        void Update(T entity);
        void Archive(TId id);
        void Unarchive(TId id);
        void Delete(TId id);
    }
}
