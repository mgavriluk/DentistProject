using AutoMapper;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Commands
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public UpdateServiceCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetById<Service>(request.Id);
            if (service == null)
            {
                throw new Exception("Service is null");
            }
            _mapper.Map(request, service);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
