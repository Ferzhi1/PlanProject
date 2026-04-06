using System;

namespace Plan.HospitalGaragoa.Application.DTOs
{
    public class MedicalRecordDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime CreatedAtRecord { get; set; }
        public string Notes { get; set; }
        public string RecordType { get; set; }
    }
}
