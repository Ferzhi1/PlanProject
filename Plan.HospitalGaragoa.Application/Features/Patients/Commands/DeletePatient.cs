using System;
using MediatR;

namespace Plan.HospitalGaragoa.Application.Features.Patients.Commands
{
    public class DeletePatient : IRequest
    {
        public Guid Id { get; set; }
    }
}
