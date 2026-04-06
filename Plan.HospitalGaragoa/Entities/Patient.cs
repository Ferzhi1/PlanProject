using Plan.HospitalGaragoa.Domain.Common;
using Plan.HospitalGaragoa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class Patient : AuditableEntity
    {
        private readonly List<MedicalRecord> _medicalRecords = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public IReadOnlyList<MedicalRecord> MedicalRecords => _medicalRecords.AsReadOnly();

        public Patient(Guid id, string createdBy, DateTime createdDate, string firstName, string lastName, DateTime dateOfBirth, Email email, PhoneNumber phoneNumber)
            : base(id, createdBy, createdDate)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName is required");
            if (dateOfBirth > DateTime.UtcNow) throw new ArgumentException("DateOfBirth cannot be in the future");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            DateOfBirth = dateOfBirth;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        public void UpdateContact(Email email, PhoneNumber phoneNumber)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            if (record == null) throw new ArgumentNullException(nameof(record));
            if (record.PatientId != Id) throw new InvalidOperationException("MedicalRecord PatientId mismatch");
            _medicalRecords.Add(record);
        }
    }
}
