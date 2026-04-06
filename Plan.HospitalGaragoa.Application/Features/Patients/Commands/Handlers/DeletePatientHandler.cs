using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Plan.HospitalGaragoa.Application.Features.Patients.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;

namespace Plan.HospitalGaragoa.Application.Features.Patients.Commands.Handlers
{
    public class DeletePatientHandler : IRequestHandler<DeletePatient>
    {
        private readonly IPatientRepository _repository;

        public DeletePatientHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePatient request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
