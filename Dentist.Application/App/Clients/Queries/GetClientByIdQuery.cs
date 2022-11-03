using AutoMapper;
using Dentist.Application.App.Discounts.Queries;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public int Id { get; set; }
    }

    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, ClientDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetClientByIdHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetById<Client>(request.Id);
            var clientDto = _mapper.Map<ClientDto>(client);
            return clientDto;
        }
    }
}
