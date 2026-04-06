using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces
{
    public interface IMedicalRecordRepository : IRepository<MedicalRecord, Guid>
    {
        Task<IEnumerable<MedicalRecord>> GetByPatientIdAsync(Guid patientId);
    }
}
