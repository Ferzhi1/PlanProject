using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Cancelled
    }

    public class Appointment : AuditableEntity
    {
        public Guid PatientId { get; private set; }
        public Guid DoctorId { get; private set; }
        public DateTime StartAt { get; private set; }
        public DateTime EndAt { get; private set; }
        public AppointmentStatus Status { get; private set; }

        public Appointment(Guid id, string createdBy, DateTime createdDate, Guid patientId, Guid doctorId, DateTime startAt, DateTime endAt)
            : base(id, createdBy, createdDate)
        {
            if (patientId == Guid.Empty) throw new ArgumentException("PatientId is required");
            if (doctorId == Guid.Empty) throw new ArgumentException("DoctorId is required");
            if (endAt <= startAt) throw new ArgumentException("EndAt must be after StartAt");
            if (startAt < DateTime.UtcNow.AddMinutes(-5)) throw new ArgumentException("StartAt cannot be in the past");

            PatientId = patientId;
            DoctorId = doctorId;
            StartAt = startAt;
            EndAt = endAt;
            Status = AppointmentStatus.Scheduled;
        }

        public void Cancel() => Status = AppointmentStatus.Cancelled;
        public void Complete() => Status = AppointmentStatus.Completed;
        public bool OverlapsWith(Appointment other)
        {
            if (other == null) return false;
            return StartAt < other.EndAt && other.StartAt < EndAt;
        }
    }
}
