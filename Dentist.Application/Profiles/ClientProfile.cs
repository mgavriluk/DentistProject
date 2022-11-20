using AutoMapper;
using Dentist.Application.App.Clients.Commands;
using Dentist.Application.App.Dtos;
using Dentist.Domain;

namespace Dentist.Application.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientCommand, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<UpdateClientCommand, Client>();
        }        
    }
}
