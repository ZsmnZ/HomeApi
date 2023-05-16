using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts;
using HomeApi.Contracts.Models.Contracts.Home;

namespace HomeApi
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, AddressInfo>();
            CreateMap<HomeOptions, InfoResponse>()
                .ForMember(m=>m.AddressInfo,
                opt=>opt.MapFrom(src=>src.Address));
        }
    }
}
