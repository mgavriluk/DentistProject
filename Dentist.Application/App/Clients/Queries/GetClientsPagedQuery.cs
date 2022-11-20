using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Application.Common.Models;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Clients.Queries
{
    public class GetClientsPagedQuery: IRequest<PaginatedResult<ClientDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetClientsPagedQueryHandler : IRequestHandler<GetClientsPagedQuery, PaginatedResult<ClientDto>>
    {
        private readonly IRepository _repository;

        public GetClientsPagedQueryHandler(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<PaginatedResult<ClientDto>> Handle(GetClientsPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedClientsDto = await _repository.GetPagedData<Client, ClientDto>(request.PagedRequest);

            return pagedClientsDto;
        }
    }
}
