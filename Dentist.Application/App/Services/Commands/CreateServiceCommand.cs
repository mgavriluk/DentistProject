using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.Common.Interfaces;
using Dentist.Domain;
using MediatR;

namespace Dentist.Application.App.Services.Commands
{
    public class CreateServiceCommand: IRequest<ServiceDto>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public CreateServiceCommandHandler(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = _mapper.Map<Service>(request);
            _repository.Add(service);

            await _repository.SaveChangesAsync();

            var serviceDto = _mapper.Map<ServiceDto>(service);

            return serviceDto;
        }
    }
}
