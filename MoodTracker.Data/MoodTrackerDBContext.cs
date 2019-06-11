using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data
{
    public class MoodTrackerDBContext : IContext, IDisposable
    {
        private readonly DbContext _context;

        public MoodTrackerDBContext()
        {
            _context = new MoodTrackerContext();
        }

        public DbContext Context { get { return _context; } }
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
