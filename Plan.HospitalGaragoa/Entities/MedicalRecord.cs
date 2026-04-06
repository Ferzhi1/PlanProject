using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class MedicalRecord : AuditableEntity
    {
        public Guid PatientId { get; private set; }
        public DateTime CreatedAtRecord { get; private set; }
        public string Notes { get; private set; }
        public string RecordType { get; private set; }

        public MedicalRecord(Guid id, string createdBy, DateTime createdDate, Guid patientId, DateTime createdAtRecord, string notes, string recordType)
            : base(id, createdBy, createdDate)
        {
            if (patientId == Guid.Empty) throw new ArgumentException("PatientId is required");
            if (createdAtRecord == default) throw new ArgumentException("CreatedAtRecord is required");
            PatientId = patientId;
            CreatedAtRecord = createdAtRecord;
            Notes = notes ?? string.Empty;
            RecordType = recordType ?? "General";
        }
    }
}
