using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Plan.HospitalGaragoa.Application.Features.Appointments.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;
using Plan.HospitalGaragoa.Application.DTOs;
using Plan.HospitalGaragoa.Domain.Entities;

namespace Plan.HospitalGaragoa.Application.Features.Appointments.Commands.Handlers
{
    public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointment, AppointmentDto>
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAppointmentHandler(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> Handle(UpdateAppointment request, CancellationToken cancellationToken)
        {
            var appointment = await _repository.GetByIdAsync(request.Id);
            if (appointment == null) throw new InvalidOperationException("Appointment not found");

            // create new appointment instance to validate invariants
            var updated = new Appointment(appointment.Id, request.CreatedBy, request.CreatedDate, request.PatientId, request.DoctorId, request.StartAt, request.EndAt);
            await _repository.UpdateAsync(updated);
            return _mapper.Map<AppointmentDto>(updated);
        }
    }
}
