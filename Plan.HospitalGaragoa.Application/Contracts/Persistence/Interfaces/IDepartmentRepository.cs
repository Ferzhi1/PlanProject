using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department, Guid>
    {
        Task<Department> GetByNameAsync(string name);
    }
}
