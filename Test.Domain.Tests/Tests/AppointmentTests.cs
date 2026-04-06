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
    }
}
