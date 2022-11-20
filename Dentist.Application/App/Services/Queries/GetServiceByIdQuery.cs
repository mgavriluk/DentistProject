using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Queries
{
    public class GetServiceByIdQuery : IRequest<ServiceDto>
    {
        public int Id { get; set; }
    }

    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, ServiceDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public GetServiceByIdHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetById<Service>(request.Id);
            var serviceDto = _mapper.Map<ServiceDto>(service);
            return serviceDto;
        }
    }
}
