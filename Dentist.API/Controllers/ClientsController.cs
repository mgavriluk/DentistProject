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

        [HttpGet]
        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clientsList = await _mediator.Send(new GetAllClientsQuery());
            return clientsList;
        }

        [HttpGet("/api/client/{id}")]
        public async Task<ClientDto> GetClient(int id)
        {
            var clientDto = await _mediator.Send(new GetClientByIdQuery { Id = id });
            return clientDto;
        }

        [HttpPost]
        public async Task<ClientDto> CreateClient(CreateClientCommand createdClient)
        {
            var clientDto = await _mediator.Send(createdClient);
            return clientDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateClient(UpdateClientCommand updatedClient)
        {
            await _mediator.Send(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task DeleteClient(int id)
        {
            await _mediator.Send(new DeleteClientCommand() { Id = id });
        }
    }
}
