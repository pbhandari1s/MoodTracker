using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Repository
{
    public abstract class BaseContext : IContext, IDisposable
    {
        public abstract DbContext Context { get; }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!this._disposed)
                if (disposing)
                    Context.Dispose();

            this._disposed = true;
        }

        public void Dispose()
        {

            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
