using System.Threading.Tasks;
using System.Threading;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Patients.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Domain.Entities;
using Plan.HospitalGaragoa.Application.DTOs;

namespace Plan.HospitalGaragoa.Application.Features.Patients.Commands.Handlers
{
    public class CreatePatientHandler : IRequestHandler<CreatePatient, PatientDto>
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;

        public CreatePatientHandler(IPatientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PatientDto> Handle(CreatePatient request, CancellationToken cancellationToken)
        {
            var patient = new Patient(request.Id, request.CreatedBy, request.CreatedDate, request.FirstName, request.LastName, request.DateOfBirth, new Plan.HospitalGaragoa.Domain.ValueObjects.Email(request.Email), new Plan.HospitalGaragoa.Domain.ValueObjects.PhoneNumber(request.PhoneNumber));
            await _repository.AddAsync(patient);
            return _mapper.Map<PatientDto>(patient);
        }
    }
}
