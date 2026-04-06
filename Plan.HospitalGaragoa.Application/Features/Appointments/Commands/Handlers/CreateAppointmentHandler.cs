using System.Threading.Tasks;
using System.Threading;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Appointments.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Domain.Entities;
using Plan.HospitalGaragoa.Application.DTOs;

namespace Plan.HospitalGaragoa.Application.Features.Appointments.Commands.Handlers
{
    public class CreateAppointmentHandler : IRequestHandler<CreateAppointment, AppointmentDto>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public CreateAppointmentHandler(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> Handle(CreateAppointment request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment(request.Id, request.CreatedBy, request.CreatedDate, request.PatientId, request.DoctorId, request.StartAt, request.EndAt);
            await _repository.AddAsync(appointment);
            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
