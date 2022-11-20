using AutoMapper;
using Dentist.Application.App.Discounts.Commands;
using Dentist.Application.App.Dtos;
using Dentist.Domain;

namespace Dentist.Application.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<CreateDiscountCommand, Discount>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<UpdateDiscountCommand, Discount>();
        }
    }
}
