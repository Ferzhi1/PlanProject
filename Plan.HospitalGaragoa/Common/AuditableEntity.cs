using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }

        public string CreatedBy { get; set; }   

        public DateTime CreatedDate { get; set; }

        protected AuditableEntity(Guid id,string createdBy,DateTime createdDate)
        {
            Id = id;
            CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
            CreatedDate = createdDate;
        }

    }
}
