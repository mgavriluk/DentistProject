using Dentist.Application.App.Clients.Commands;
using Dentist.Application.App.Clients.Queries;
using Dentist.Application.App.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers
{
    [Route("api/clients")]
    public class ClientsController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ClientDto> CreateClient(CreateClientCommand createdClient)
        {
            var clientDto = await _mediator.Send(createdClient);
            return clientDto;
        }
    }
}
