using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Plan.HospitalGaragoa.Application.Features.Appointments.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;

namespace Plan.HospitalGaragoa.Application.Features.Appointments.Commands.Handlers
{
    public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointment>
    {
        private readonly IAppointmentRepository _repository;

        public DeleteAppointmentHandler(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAppointment request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
