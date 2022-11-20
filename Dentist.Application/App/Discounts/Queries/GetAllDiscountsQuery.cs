using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Queries
{
    public class GetAllDiscountsQuery : IRequest<IEnumerable<DiscountDto>>
    {
    }

    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<DiscountDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetAllDiscountsQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<DiscountDto>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var discountsList = await _repository.GetAll<Discount>();
            var discountsDtoList = _mapper.Map<IEnumerable<DiscountDto>>(discountsList);
            return discountsDtoList;
        }
    }
}
