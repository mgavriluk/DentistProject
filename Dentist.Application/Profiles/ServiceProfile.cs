using AutoMapper;
using Dentist.Application.App.Dtos;
using Dentist.Application.App.Services.Commands;
using Dentist.Domain;

namespace Dentist.Application.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceCommand, Service>();
            CreateMap<Service, ServiceDto>();
            CreateMap<UpdateServiceCommand, Service>();
        }
    }
}