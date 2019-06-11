using MoodTracker.Core.Helper;
using MoodTracker.Core.Repository;
using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Data
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        private readonly IDbAuditLogger _logger;

        public EfUnitOfWork(IContext context, IDbAuditLogger logger)
        {
            _context = context;
            _logger = logger;
        }


        public void SaveChanges()
        {

            using (var transaction = _context.Context.Database.BeginTransaction())
            {
                try
                {
                    _logger.SetAuditTrail();

                    _context.Context.SaveChanges();
                    transaction.Commit();
                }
                catch (DbEntityValidationException ex)
                {
                    transaction.Rollback();
                    throw new Exception(DbEntryValidationExceptionHelper.GetFullErrorText(ex), ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message, ex);
                }
            }
        }
    }
}
