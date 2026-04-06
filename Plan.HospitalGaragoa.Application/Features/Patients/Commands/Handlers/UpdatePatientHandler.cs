using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Patients.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Application.DTOs;
using Plan.HospitalGaragoa.Domain.ValueObjects;

namespace Plan.HospitalGaragoa.Application.Features.Patients.Commands.Handlers
{
    public class UpdatePatientHandler : IRequestHandler<UpdatePatient, PatientDto>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public UpdatePatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(UpdatePatient request, CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id);
            if (patient == null) throw new InvalidOperationException("Patient not found");

            // update contact via domain method
            patient.UpdateContact(new Email(request.Email), new PhoneNumber(request.PhoneNumber));

            // update simple properties using private setter access via reflection where needed
            var type = patient.GetType();
            var firstNameProp = type.GetProperty("FirstName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            var lastNameProp = type.GetProperty("LastName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            var dobProp = type.GetProperty("DateOfBirth", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

            firstNameProp?.SetValue(patient, request.FirstName?.Trim());
            lastNameProp?.SetValue(patient, request.LastName?.Trim());
            dobProp?.SetValue(patient, request.DateOfBirth);

            await _repository.UpdateAsync(patient);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}
