using Plan.HospitalGaragoa.Domain.Common;
using Plan.HospitalGaragoa.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class Doctor : AuditableEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Specialty { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        public Doctor(Guid id, string createdBy, DateTime createdDate, string firstName, string lastName, string specialty, Email email, PhoneNumber phoneNumber)
            : base(id, createdBy, createdDate)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName is required");
            if (string.IsNullOrWhiteSpace(specialty)) throw new ArgumentException("Specialty is required");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Specialty = specialty.Trim();
            Email = email ?? throw new ArgumentNullException(nameof(email));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }
    }
}
