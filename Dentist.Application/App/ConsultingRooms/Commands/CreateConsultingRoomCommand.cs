using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.ConsultingRooms.Commands
{
    public class CreateConsultingRoomCommand : IRequest<ConsultingRoomDto>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? OfficeNumber { get; set; }
    }

    public class CreateConsultingRoomCommandHandler : IRequestHandler<CreateConsultingRoomCommand, 
        ConsultingRoomDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateConsultingRoomCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ConsultingRoomDto> Handle(CreateConsultingRoomCommand request, 
            CancellationToken cancellationToken)
        {
            var consultingRoom = _mapper.Map<ConsultingRoom>(request);

            _repository.Add(consultingRoom);

            await _repository.SaveChangesAsync();

            var consultingRoomDto = _mapper.Map<ConsultingRoomDto>(consultingRoom);

            return consultingRoomDto;
        }
    }
}
