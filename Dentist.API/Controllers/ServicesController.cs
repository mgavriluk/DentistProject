using Dentist.Application.App.Dtos;
using Dentist.Application.App.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers
{
    [Route("api/services")]
    public class ServicesController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceDto>> GetAllServices()
        {
            var serviceList = await _mediator.Send(new GetAllServicesQuery());
            return serviceList;
        }
    }
}
