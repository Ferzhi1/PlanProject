using System.Threading.Tasks;
using System.Threading;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Doctors.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Domain.Entities;
using Plan.HospitalGaragoa.Application.DTOs;

namespace Plan.HospitalGaragoa.Application.Features.Doctors.Commands.Handlers
{
    public class CreateDoctorHandler : IRequestHandler<CreateDoctor, DoctorDto>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public CreateDoctorHandler(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(CreateDoctor request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor(request.Id, request.CreatedBy, request.CreatedDate, request.FirstName, request.LastName, request.Specialty, new Plan.HospitalGaragoa.Domain.ValueObjects.Email(request.Email), new Plan.HospitalGaragoa.Domain.ValueObjects.PhoneNumber(request.PhoneNumber));
            await _repository.AddAsync(doctor);
            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
