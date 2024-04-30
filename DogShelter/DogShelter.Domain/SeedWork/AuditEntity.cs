using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogShelter.Domain.SeedWork
{
    public class AuditEntity : EntityBase, IEntityCanCreate, IEntityCanUpdate
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
