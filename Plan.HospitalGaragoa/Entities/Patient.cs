using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public  class Patient:AuditableEntity
    {
        private readonly List<MedicalRecord> _medicalRecords = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public IReadOnlyList<MedicalRecord> MedicalRecords => _medicalRecords.AsReadOnly();

        public Patient(Guid id, string createdBy, DateTime createdDate, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
            : base(id, createdBy, createdDate)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName is required");
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            if (record.PatientId != Id) throw new InvalidOperationException("MedicalRecord PatientId mismatch");
            _medicalRecords.Add(record);
        }
    }
}
