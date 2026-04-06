using System;
using MediatR;

namespace Plan.HospitalGaragoa.Application.Features.Appointments.Commands
{
    public class DeleteAppointment : IRequest
    {
        public Guid Id { get; set; }
    }
}
