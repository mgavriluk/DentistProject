using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Queries
{
    public class GetAllServicesQuery  : IRequest<IEnumerable<ServiceDto>>
    {
    }

    public class GetAllServicesCommandHandler : IRequestHandler<GetAllServicesQuery, IEnumerable<ServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetAllServicesCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var servicesList = await _repository.GetAll<Service>();
            var servicesDtoList = _mapper.Map<IEnumerable<ServiceDto>>(servicesList);
            return servicesDtoList;
        }
    }
}
