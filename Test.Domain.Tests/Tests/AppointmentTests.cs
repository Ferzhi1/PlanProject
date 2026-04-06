using System;
using Xunit;
using Plan.HospitalGaragoa.Domain.Entities;

namespace Test.Domain.Tests
{
    public class AppointmentTests
    {

        [Fact]
        public void CreatingAppointment_WithEndBeforeStart_Throws()
        {
            var start = DateTime.UtcNow.AddHours(2);
            var end = DateTime.UtcNow.AddHours(1);
            Assert.Throws<ArgumentException>(() =>
                new Appointment(Guid.NewGuid(), "system", DateTime.UtcNow, Guid.NewGuid(), Guid.NewGuid(), start, end));
        }

        [Fact]
        public void OverlapsWith_ReturnsTrueForOverlappingAppointments()
        {
            var start1 = DateTime.UtcNow.AddHours(1);
            var end1 = start1.AddMinutes(30);
            var a1 = new Appointment(Guid.NewGuid(), "system", DateTime.UtcNow, Guid.NewGuid(), Guid.NewGuid(), start1, end1);

            var start2 = start1.AddMinutes(15);
            var end2 = start2.AddMinutes(30);
            var a2 = new Appointment(Guid.NewGuid(), "system", DateTime.UtcNow, a1.PatientId, a1.DoctorId, start2, end2);

            Assert.True(a1.OverlapsWith(a2));
        }

    }
}
