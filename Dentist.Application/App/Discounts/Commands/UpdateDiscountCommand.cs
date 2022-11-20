using AutoMapper;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Commands
{
    public class UpdateDiscountCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public UpdateDiscountCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discount = await _repository.GetById<Discount>(request.Id);

            if (discount == null)
            {
                throw new Exception("Discount is null");
            }

            _mapper.Map(request, discount);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
