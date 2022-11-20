using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Commands
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IRepository _repository;

        public DeleteClientCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<Client>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
