using System;
using MediatR;

namespace Plan.HospitalGaragoa.Application.Features.Doctors.Commands
{
    public class DeleteDoctor : IRequest
    {
        public Guid Id { get; set; }
    }
}
