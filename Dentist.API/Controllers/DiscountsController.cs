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

        [HttpGet("/api/discount/{id}")]
        public async Task<DiscountDto> GetDiscount(int id)
        {
            var discountDto = await _mediator.Send(new GetDiscountByIdQuery { Id = id });
            return discountDto;
        }

        [HttpPost]
        public async Task<DiscountDto> CreateDiscount(CreateDiscountCommand createdDiscount)
        {
            var discountDto = await _mediator.Send(createdDiscount);
            return discountDto;
        }

        [HttpPut("{id}")]
        public async Task UpdateDiscount(UpdateDiscountCommand updatedDiscount)
        {
            await _mediator.Send(updatedDiscount);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDiscount(int id)
        {
            await _mediator.Send(new DeleteDiscountCommand() { Id = id });
        }
    }
}
