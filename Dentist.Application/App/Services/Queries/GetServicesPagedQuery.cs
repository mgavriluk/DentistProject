using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Application.Common.Models;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Queries
{
    public class GetServicesPagedQuery: IRequest<PaginatedResult<ServiceDto>>
    {
        public PagedRequest PagedRequest { get; set; }
    }

    public class GetServicesPagedQueryHandler : IRequestHandler<GetServicesPagedQuery,
        PaginatedResult<ServiceDto>>
    {
        private readonly IRepository _repository;

        public GetServicesPagedQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<ServiceDto>> Handle(GetServicesPagedQuery request, CancellationToken cancellationToken)
        {
            var pagedServicesDto = await _repository.GetPagedData<Service, ServiceDto>(request.PagedRequest);
            return pagedServicesDto;
        }
    }
}
