using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Commands
{
    public class CreateClientCommand : IRequest<ClientDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public int? DiscountId { get; set; }
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, ClientDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateClientCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Client>(request);

            _repository.Add(client);

            await _repository.SaveChangesAsync();

            var clientDto = _mapper.Map<ClientDto>(client);

            return clientDto;
        }
    }
}
