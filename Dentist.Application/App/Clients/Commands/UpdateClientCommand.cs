using AutoMapper;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Commands
{
    public class UpdateClientCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public int? DiscountId { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public UpdateClientCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetById<Client>(request.Id);

            if (client == null)
            {
                throw new Exception("Client is null");
            }

            _mapper.Map(request, client);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
