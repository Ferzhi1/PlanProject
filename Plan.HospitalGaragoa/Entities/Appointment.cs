using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class Appointment : AuditableEntity
    {
        public enum AppointmentStatus
        {
            Scheduled,
            Completed,
            Cancelled
        }

       
            public Guid PatientId { get; private set; }
            public Guid DoctorId { get; private set; }
            public DateTime StartAt { get; private set; }
            public DateTime EndAt { get; private set; }
            public AppointmentStatus Status { get; private set; }

            public Appointment(Guid id, string createdBy, DateTime createdDate, Guid patientId, Guid doctorId, DateTime startAt, DateTime endAt)
                : base(id, createdBy, createdDate)
            {
                if (endAt <= startAt) throw new ArgumentException("EndAt must be after StartAt");
                PatientId = patientId;
                DoctorId = doctorId;
                StartAt = startAt;
                EndAt = endAt;
                Status = AppointmentStatus.Scheduled;
            }

            public void Cancel() => Status = AppointmentStatus.Cancelled;
            public void Complete() => Status = AppointmentStatus.Completed;
        
    }
}
