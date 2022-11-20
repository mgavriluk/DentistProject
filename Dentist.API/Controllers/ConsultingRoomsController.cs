using Dentist.Application.App.ConsultingRooms.Commands;
using Dentist.Application.App.ConsultingRooms.Queries;
using Dentist.Application.App.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers
{
    [Route("api/consultingRooms")]
    public class ConsultingRoomsController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultingRoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ConsultingRoomDto>> GetAllConsultingRooms()
        {
            var consultingRoomsDto = await _mediator.Send(new GetAllConsultingRoomsQuery());
            return consultingRoomsDto;
        }

        [HttpGet("/api/consultingRoom/{id}")]
        public async Task<ConsultingRoomDto> GetConsultingRoom(int id)
        {
            var consultingRoomDto = await _mediator.Send(new GetConsultingRoomByIdQuery { Id = id });
            return consultingRoomDto;
        }

        [HttpPost]
        public async Task<ConsultingRoomDto> CreateConsultingRoom(CreateConsultingRoomCommand createdConsultingRoom)
        {
            var consultingRoomDto = await _mediator.Send(createdConsultingRoom);
            return consultingRoomDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateConsultingRoom(UpdateConsultingRoomCommand updatedConsultingRoom)
        {
            await _mediator.Send(updatedConsultingRoom);
        }

        [HttpDelete("{id}")]
        public async Task DeleteConsultingRoom(int id)
        {
            await _mediator.Send(new DeleteConsultingRoomCommand() { Id = id });
        }
    }
}
