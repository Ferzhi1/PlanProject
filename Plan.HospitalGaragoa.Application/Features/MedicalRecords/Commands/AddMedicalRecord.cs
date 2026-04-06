using System;

namespace Plan.HospitalGaragoa.Application.Features.MedicalRecords.Commands
{
    public class AddMedicalRecord
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PatientId { get; set; }
        public DateTime CreatedAtRecord { get; set; }
        public string Notes { get; set; }
        public string RecordType { get; set; }
    }
}
