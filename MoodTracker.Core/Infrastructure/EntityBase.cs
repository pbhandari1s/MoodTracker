using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker.Core.Infrastructure
{
    public abstract class EntityBase<TIdType> : IEntity<TIdType>, IValidatable, IAuditLog<TIdType>, IArchivable
    {
        protected EntityBase()
        {
            IsArchived = false;
        }

        [Key]
        public TIdType Id { get; set; }
        public DateTime CreationStamp { get; set; }
        public DateTime? ModificationStamp { get; set; }
        public string Addedby { get; set; }
        public string ModifiedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Timestamp]
        public byte[] Version { get; protected set; }

        public bool IsArchived { get; set; }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<TIdType>
               && this == (EntityBase<TIdType>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TIdType> entity1, EntityBase<TIdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TIdType> entity1,
            EntityBase<TIdType> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
