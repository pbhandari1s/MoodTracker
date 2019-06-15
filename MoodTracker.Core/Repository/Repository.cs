using MoodTracker.Core.CustomException;
using MoodTracker.Core.Infrastructure;
using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public abstract class Repository<T, TId> : IDisposable where T : class, IEntity<TId>, IArchivable
    {
        internal DbSet<T> DbSet;
        private readonly DbContext _context;

        protected Repository(IContext context)
        {
            Contract.Requires<ArgumentNullException>(context != null, nameof(context));

            _context = context.Context;
            this.DbSet = _context.Set<T>();
            
        }


        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Get();
        }

        public virtual T GetById(TId id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            //DbSet.Add(entity);
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Archive(TId id)
        {
            var entityToDelete = DbSet.Find(id);

            var archive = entityToDelete as IArchivable;

            if (archive != null)
                archive.IsArchived = true;

            //Delete(entityToDelete);
            Update(entityToDelete);
        }

        public virtual void Unarchive(TId id)
        {
            var entityToUnarchive = DbSet.Find(id);

            var unarchive = entityToUnarchive as IArchivable;

            if (unarchive != null)
                unarchive.IsArchived = false;

            Update(entityToUnarchive);
        }

        public virtual void Archive(T entityToDelete)
        {
            var archive = entityToDelete as IArchivable;

            if (archive != null)
                archive.IsArchived = true;

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }

            //DbSet.Remove(entityToDelete);
            Update(entityToDelete);
        }

        public virtual void Delete(TId id)
        {
            var entityToDelete = DbSet.Find(id);
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            //this has to be done for the auditlog
            var record = DbSet.First(EqualsPredicate(entityToUpdate.Id));
            _context.Entry(record).CurrentValues.SetValues(entityToUpdate);

            //this is the usual way of attaching a disconnected entity
            //DbSet.Attach(entityToUpdate);
            //_context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        protected static Expression<Func<T, bool>> EqualsPredicate(TId id)
        {
            Expression<Func<T, TId>> selector = x => x.Id;
            Expression<Func<TId>> closure = () => id;
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(selector.Body, closure.Body),
                selector.Parameters);
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
                if (disposing)
                    _context.Dispose();

            this._disposed = true;
        }
        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
