using Plan.HospitalGaragoa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment, Guid>
    {
        Task<IEnumerable<Appointment>> GetByPatientIdAsync(Guid patientId);
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetByDateRangeAsync(DateTime from, DateTime to);
    }
}
