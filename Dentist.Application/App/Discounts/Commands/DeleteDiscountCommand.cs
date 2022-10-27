using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Discounts.Commands
{
    public class DeleteDiscountCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand>
    {
        private readonly IRepository _repository;

        public DeleteDiscountCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete<Discount>(request.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
