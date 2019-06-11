using MoodTracker.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public class GenericEqualPredicate<T, TId> where T : class, IEntity<TId>
    {
        protected static Expression<Func<T, bool>> EqualsPredicate(TId id)
        {
            Expression<Func<T, TId>> selector = x => x.Id;
            Expression<Func<TId>> closure = () => id;
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(selector.Body, closure.Body),
                selector.Parameters);
        }
    }
}
