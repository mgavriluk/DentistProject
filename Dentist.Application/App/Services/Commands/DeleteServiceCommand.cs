using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Commands
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IRepository _repository;

        public DeleteServiceCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<Service>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
