using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDto>>
    {
    }

    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetAllClientsQueryHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ClientDto>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var clientsList = await _repository.GetAll<Client>();
            var clientsDtoList = _mapper.Map<IEnumerable<ClientDto>>(clientsList);
            return clientsDtoList;
        }
    }
}
