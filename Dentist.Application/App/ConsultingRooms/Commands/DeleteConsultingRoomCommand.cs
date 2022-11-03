using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.ConsultingRooms.Commands
{
    public class DeleteConsultingRoomCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteConsultingRoomCommandHandler : IRequestHandler<DeleteConsultingRoomCommand>
    {
        private readonly IRepository _repository;

        public DeleteConsultingRoomCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteConsultingRoomCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<ConsultingRoom>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
