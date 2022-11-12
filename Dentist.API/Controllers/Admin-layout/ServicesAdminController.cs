using Dentist.Application.App.Dtos;
using Dentist.Application.App.Services.Commands;
using Dentist.Application.App.Services.Queries;
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
        public async Task<IEnumerable<ServiceDto>> GetAllServices()
        {
            var serviceList = await _mediator.Send(new GetAllServicesQuery());
            return serviceList;
        }

        [HttpGet("/api/admin/service/{id}")]
        public async Task<ServiceDto> GetService(int id)
        {
            var serviceDto = await _mediator.Send(new GetServiceByIdQuery { Id = id });
            return serviceDto;
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
