using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.ConsultingRooms.Queries
{
    public class GetAllConsultingRoomsQuery : IRequest<IEnumerable<ConsultingRoomDto>>
    {
    }

    public class GetAllConsultingRoomsQueryHandler : IRequestHandler<GetAllConsultingRoomsQuery,
        IEnumerable<ConsultingRoomDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetAllConsultingRoomsQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ConsultingRoomDto>> Handle(GetAllConsultingRoomsQuery request, 
            CancellationToken cancellationToken)
        {
            var consultingRoomsList = await _repository.GetAll<ConsultingRoom>();
            var consultingRoomsDtoList = _mapper.Map<IEnumerable<ConsultingRoomDto>>(consultingRoomsList);
            return consultingRoomsDtoList;
        }
    }
}
