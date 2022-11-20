using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Application.Common.Models;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Queries
{
    public class GetDiscountsPagedQuery: IRequest<PaginatedResult<DiscountDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetDiscountsPagedQueryHandler : IRequestHandler<GetDiscountsPagedQuery, PaginatedResult<DiscountDto>>
    {
        private readonly IRepository _repository;

        public GetDiscountsPagedQueryHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedResult<DiscountDto>> Handle(GetDiscountsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedDiscountsDto = await _repository.GetPagedData<Discount, DiscountDto>(request.PagedRequest);

            return pagedDiscountsDto;
        }
    }
}
