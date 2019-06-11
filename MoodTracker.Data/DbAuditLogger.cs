using MoodTracker.Core.Infrastructure;
using MoodTracker.Core.Repository;
using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data
{
    public class DbAuditLogger : IDbAuditLogger
    {
        private readonly IAuthenticatedUser<int> _authenticatedUsers;
        private readonly IContext _context;

        public DbAuditLogger(IAuthenticatedUser<int> authenticatedUsers, IContext context)
        {
            _authenticatedUsers = authenticatedUsers;
            _context = context;
        }

        public void SetAuditTrail()
        {
            var now = DateTime.UtcNow;
            HandleUpdates(now);
            HandleInserts(now);
        }


        private void HandleUpdates(DateTime date)
        {
            var modifiedAuditedEntities = _context.Context.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);
            foreach (var entity in modifiedAuditedEntities)
            {
                var item = entity as IAuditLog<int>;

                if (item != null)
                {
                    item.ModificationStamp = date;
                    item.ModifiedBy = _authenticatedUsers.Id != null ? _authenticatedUsers.Id.ToString() : "";
                }
            }
        }

        private void HandleInserts(DateTime date)
        {
            var addedAuditedEntities = _context.Context.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);
            foreach (var entity in addedAuditedEntities)
            {
                var item = entity as IAuditLog<int>;

                if (item != null)
                {
                    item.Addedby = _authenticatedUsers.Id != null ? _authenticatedUsers.Id.ToString() : "";
                    item.CreationStamp = date;
                }
            }
        }
    }
}
