using System;
using MediatR;
using Plan.HospitalGaragoa.Application.DTOs;

namespace Plan.HospitalGaragoa.Application.Features.Appointments.Commands
{
    public class UpdateAppointment : IRequest<AppointmentDto>
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
    }
}
