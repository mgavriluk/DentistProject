using Dentist.Application.App.Discounts.Commands;
using Dentist.Application.App.Discounts.Queries;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dentist.API.Controllers.Admin_layout
{
    [Route("api/admin/discounts")]
    public class DiscountsAdminController : AdminLayoutBaseController
    {
        private readonly IMediator _mediator;

        public DiscountsAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedResult<DiscountDto>> GetPagedDiscounts([FromQuery] PagedRequest pagedRequest)
        {
            var responce = await _mediator.Send(new GetDiscountsPagedQuery() { PagedRequest = pagedRequest });
            return responce;
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
