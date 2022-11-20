using AutoMapper;
using Dentist.Application.App.ConsultingRooms.Commands;
using Dentist.Application.App.Dtos;
using Dentist.Domain;

namespace Dentist.Application.Profiles
{
    public class ConsultingRoomProfile : Profile
    {
        public ConsultingRoomProfile()
        {
            CreateMap<CreateConsultingRoomCommand, ConsultingRoom>();
            CreateMap<ConsultingRoom, ConsultingRoomDto>();
            CreateMap<UpdateConsultingRoomCommand, ConsultingRoom>();
        }
    }
}
