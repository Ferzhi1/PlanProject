using Plan.HospitalGaragoa.Domain.Entities;
using Plan.HospitalGaragoa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.Domain.Tests
{
    public class PatientTests
    {
        [Fact]
        public void PatientCreation_WithInvalidEmail_Throws()
        {
            var id = Guid.NewGuid();
            var dob = DateTime.UtcNow.AddYears(-30);
            Assert.Throws<ArgumentException>(() =>
                new Patient(id, "system", DateTime.UtcNow, "John", "Doe", dob, new Email("invalid"), new PhoneNumber("+123456789")));
        }

        [Fact]
        public void AddMedicalRecord_WithMismatchedPatientId_Throws()
        {
            var id = Guid.NewGuid();
            var patient = new Patient(id, "system", DateTime.UtcNow, "Jane", "Doe", DateTime.UtcNow.AddYears(-25), new Email("jane@example.com"), new PhoneNumber("+123456789"));
            var record = new MedicalRecord(Guid.NewGuid(), "system", DateTime.UtcNow, Guid.NewGuid(), DateTime.UtcNow, "notes", "Consultation");
            Assert.Throws<InvalidOperationException>(() => patient.AddMedicalRecord(record));
        }
    }
}
