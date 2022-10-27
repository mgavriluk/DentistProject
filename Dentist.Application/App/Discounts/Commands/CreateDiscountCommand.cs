using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Commands
{
    public class CreateDiscountCommand: IRequest<DiscountDto>
    {
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, DiscountDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateDiscountCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<DiscountDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = _mapper.Map<Discount>(request);

            _repository.Add(discount);

            await _repository.SaveChangesAsync();

            var discountDto = _mapper.Map<DiscountDto>(discount);

            return discountDto;
        }
    }
}
