using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor, Guid>
    {
        Task<IEnumerable<Doctor>> GetBySpecialtyAsync(string specialty);
    }
}
