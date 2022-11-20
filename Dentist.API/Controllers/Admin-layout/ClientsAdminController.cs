using Dentist.Application.App.Clients.Commands;
using Dentist.Application.App.Clients.Queries;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers.Admin_layout
{
    [Route("api/admin/clients")]
    public class ClientsAdminController : AdminLayoutBaseController
    {
        private readonly IMediator _mediator;

        public ClientsAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedResult<ClientDto>> GetPagedClients([FromQuery] PagedRequest pagedRequest)
        {
            var responce = await _mediator.Send(new GetClientsPagedQuery() { PagedRequest = pagedRequest});
            return responce;
        }

        [HttpPost]
        public async Task<ClientDto> CreateClient(CreateClientCommand createClient)
        {
            var clientDto = await _mediator.Send(createClient);
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
