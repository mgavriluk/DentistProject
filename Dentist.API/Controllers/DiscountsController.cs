using Dentist.Application.App.Discounts.Commands;
using Dentist.Application.App.Discounts.Queries;
using Dentist.Application.App.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers
{
    [Route("api/discounts")]
    public class DiscountsController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountDto>> GetAllDiscounts()
        {
            var discountsList = await _mediator.Send(new GetAllDiscountsQuery());
            return discountsList;
        }       
    }
}
