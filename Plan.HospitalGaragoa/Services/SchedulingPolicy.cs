using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Services
{

    public class SchedulingPolicy
    {
        private readonly TimeSpan _doctorBuffer;

        public SchedulingPolicy(TimeSpan doctorBuffer)
        {
            if (doctorBuffer < TimeSpan.Zero) throw new ArgumentException("Buffer must be non-negative");
            _doctorBuffer = doctorBuffer;
        }

        public bool CanSchedule(Appointment candidate, IEnumerable<Appointment> existingAppointments)
        {
            if (candidate == null) throw new ArgumentNullException(nameof(candidate));
            var existingForDoctor = existingAppointments?
                .Where(a => a.DoctorId == candidate.DoctorId && a.Id != candidate.Id)
                .ToList() ?? new List<Appointment>();

            foreach (var appt in existingForDoctor)
            {
                var bufferedStart = appt.StartAt - _doctorBuffer;
                var bufferedEnd = appt.EndAt + _doctorBuffer;
                if (candidate.StartAt < bufferedEnd && bufferedStart < candidate.EndAt) return false;
            }

            return true;
        }
    }
}
