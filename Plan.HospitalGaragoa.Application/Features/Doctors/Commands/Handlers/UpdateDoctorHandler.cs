using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Doctors.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Application.DTOs;
using Plan.HospitalGaragoa.Domain.ValueObjects;

namespace Plan.HospitalGaragoa.Application.Features.Doctors.Commands.Handlers
{
    public class UpdateDoctorHandler : IRequestHandler<UpdateDoctor, DoctorDto>
    {
        private readonly IDoctorRepository _repository;
        private readonly IMapper _mapper;

        public UpdateDoctorHandler(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> Handle(UpdateDoctor request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.GetByIdAsync(request.Id);
            if (doctor == null) throw new InvalidOperationException("Doctor not found");

            var type = doctor.GetType();
            var firstNameProp = type.GetProperty("FirstName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            var lastNameProp = type.GetProperty("LastName", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            var specialtyProp = type.GetProperty("Specialty", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

            firstNameProp?.SetValue(doctor, request.FirstName?.Trim());
            lastNameProp?.SetValue(doctor, request.LastName?.Trim());
            specialtyProp?.SetValue(doctor, request.Specialty?.Trim());

            doctor = new Plan.HospitalGaragoa.Domain.Entities.Doctor(doctor.Id, request.CreatedBy, request.CreatedDate, request.FirstName, request.LastName, request.Specialty, new Email(request.Email), new Plan.HospitalGaragoa.Domain.ValueObjects.PhoneNumber(request.PhoneNumber));

            await _repository.UpdateAsync(doctor);
            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
