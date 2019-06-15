using AutoMapper;
using MoodTracker.Core.CustomException;
using MoodTracker.Core.Infrastructure;
using MoodTracker.Core.Repository;
using MoodTracker.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Entities.Service
{
    public abstract class BaseFilterService<T, TViewModel, TId> where T : class, IAggregateRoot, IEntity<TId>, IArchivable
    {
        protected readonly IRepository<T, TId> Repository;
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected BaseFilterService(IRepository<T, TId> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            Contract.Requires<ArgumentNullException>(unitOfWork != null, nameof(unitOfWork));
            Contract.Requires<ArgumentNullException>(repository != null, nameof(repository));
            Contract.Requires<ArgumentNullException>(mapper != null, nameof(mapper));

            Repository = repository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public IEnumerable<TViewModel> GetAll()
        {
            var result = Repository.GetAll();

            return Mapper.Map<IEnumerable<TViewModel>>(result);
        }

        public IEnumerable<TViewModel> GetAllActive()
        {
            var result = Repository.Get(x => !x.IsArchived);

            return Mapper.Map<IEnumerable<TViewModel>>(result);
        }


        public IEnumerable<TViewModel> GetArchived()
        {
            var result = Repository.Get(x => x.IsArchived);

            return Mapper.Map<IEnumerable<TViewModel>>(result);
        }

        public void Archive(TId id)
        {
            Repository.Archive(id);
            UnitOfWork.SaveChanges();
        }

        public void Unarchive(TId id)
        {
            Repository.Unarchive(id);
            UnitOfWork.SaveChanges();
        }

        public void Delete(TId id)
        {
            Repository.Delete(id);
            UnitOfWork.SaveChanges();
        }

        public int GetTotalCount()
        {
            var records = Repository.GetAll().Where(x => x.IsArchived == false);

            return records.Count();
        }

        public TViewModel GetById(TId id)
        {
            var item = Repository.GetById(id);

            if (item == null)
                throw new RecordNotFoundException();

            return Mapper.Map<TViewModel>(item);
        }
    }
}
