using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces
{
    public interface IPatientRepository : IRepository<Patient, Guid>
    {
        Task<Patient> GetByEmailAsync(string email);
    }
}
