using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Queries
{
    public class GetDiscountByIdQuery : IRequest<DiscountDto>
    {
        public int Id { get; set; }
    }

    public class GetDiscountByIdQueryHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetDiscountByIdQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<DiscountDto> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var discount = await _repository.GetById<Discount>(request.Id);
            var discountDto = _mapper.Map<DiscountDto>(discount);
            return discountDto;
        }
    }
}
