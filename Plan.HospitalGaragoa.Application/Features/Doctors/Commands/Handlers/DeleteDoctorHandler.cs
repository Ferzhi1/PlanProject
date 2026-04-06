using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Plan.HospitalGaragoa.Application.Features.Doctors.Commands;
using Plan.HospitalGaragoa.Application.Contracts.Persistence.Interfaces;

namespace Plan.HospitalGaragoa.Application.Features.Doctors.Commands.Handlers
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctor>
    {
        private readonly IDoctorRepository _repository;

        public DeleteDoctorHandler(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDoctor request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
