using Plan.HospitalGaragoa.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Domain.Entities
{
    public class Department : AuditableEntity
    {
        private readonly List<Guid> _doctorIds = new();

        public string Name { get; private set; }
        public string Location { get; private set; }
        public IReadOnlyList<Guid> DoctorIds => _doctorIds.AsReadOnly();

        public Department(Guid id, string createdBy, DateTime createdDate, string name, string location)
            : base(id, createdBy, createdDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
            Name = name.Trim();
            Location = location?.Trim();
        }

        public void AddDoctor(Guid doctorId)
        {
            if (doctorId == Guid.Empty) throw new ArgumentException("doctorId is required");
            if (!_doctorIds.Contains(doctorId)) _doctorIds.Add(doctorId);
        }
    }
}
