using AutoMapper;

namespace CustomerMinimalApiWS.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Customer, Models.CustomerDto>();
            CreateMap<Entities.Address, Models.AddressDto>();
            CreateMap<Models.CustomerDto, Entities.Customer>();
        }
    }
}
