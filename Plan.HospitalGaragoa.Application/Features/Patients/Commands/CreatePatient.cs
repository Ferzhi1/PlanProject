using System;
using MediatR;
using Plan.HospitalGaragoa.Application.DTOs;

namespace Plan.HospitalGaragoa.Application.Features.Patients.Commands
{
    public class CreatePatient : IRequest<PatientDto>
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
