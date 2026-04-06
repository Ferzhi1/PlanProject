using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class Doctor: AuditableEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Specialty { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Doctor(Guid id, string createdBy, DateTime createdDate, string firstName, string lastName, string specialty, string email, string phoneNumber)
            : base(id, createdBy, createdDate)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("FirstName is required");
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("LastName is required");
            FirstName = firstName;
            LastName = lastName;
            Specialty = specialty;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
