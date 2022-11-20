using Dentist.Application.App.Dtos;
using Dentist.Application.App.Services.Commands;
using Dentist.Application.App.Services.Queries;
using Dentist.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers.Admin_layout
{
    [Route("api/admin/dentist-services")]
    public class ServicesAdminController : AdminLayoutBaseController
    {
        private readonly IMediator _mediator;

        public ServicesAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedResult<ServiceDto>> GetPagedServices([FromQuery] PagedRequest pagedRequest)
        {
            var responce = await _mediator.Send(new GetServicesPagedQuery() { PagedRequest = pagedRequest });
            return responce;
        }

        [HttpPost]
        public async Task<ServiceDto> CreateService(CreateServiceCommand createdService)
        {
            var serviceDto = await _mediator.Send(createdService);
            return serviceDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateService(UpdateServiceCommand updatedService)
        {
            await _mediator.Send(updatedService);
        }

        [HttpDelete("{id}")]
        public async Task DeleteService(int id)
        {
            await _mediator.Send(new DeleteServiceCommand() { Id = id });
        }
    }
}
