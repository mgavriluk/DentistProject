using AutoMapper;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.ConsultingRooms.Commands
{
    public class UpdateConsultingRoomCommand : IRequest
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? OfficeNumber { get; set; }
    }

    public class UpdateConsultingRoomCommandHandler : IRequestHandler<UpdateConsultingRoomCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public UpdateConsultingRoomCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateConsultingRoomCommand request, CancellationToken cancellationToken)
        {
            var consultingRoom = await _repository.GetById<ConsultingRoom>(request.Id);

            if (consultingRoom == null)
            {
                throw new Exception("Consulting room is null");
            }

            _mapper.Map(request, consultingRoom);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
