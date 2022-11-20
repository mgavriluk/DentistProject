using AutoMapper;
using Dentist.Application.App.Clients.Queries;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.ConsultingRooms.Queries
{
    public class GetConsultingRoomByIdQuery : IRequest<ConsultingRoomDto>
    {
        public int Id { get; set; }
    }

    public class GetConsultingRoomByIdQueryHandler : IRequestHandler<GetConsultingRoomByIdQuery,
        ConsultingRoomDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetConsultingRoomByIdQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ConsultingRoomDto> Handle(GetConsultingRoomByIdQuery request, 
            CancellationToken cancellationToken)
        {
            var consultingRoom = await _repository.GetById<ConsultingRoom>(request.Id);
            var consultingRoomDto = _mapper.Map<ConsultingRoomDto>(consultingRoom);
            return consultingRoomDto;
        }
    }
}
