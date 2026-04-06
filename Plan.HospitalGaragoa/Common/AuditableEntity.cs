using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

        protected AuditableEntity(Guid id, string createdBy, DateTime createdDate)
        {
            if (id == Guid.Empty) throw new ArgumentException("Id is required");
            Id = id;
            CreatedBy = string.IsNullOrWhiteSpace(createdBy) ? throw new ArgumentNullException(nameof(createdBy)) : createdBy;
            CreatedDate = createdDate == default ? DateTime.UtcNow : createdDate;
        }
    }
}
