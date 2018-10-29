using Asp.Net_Identity.DTO;
using Asp.Net_Identity.Models;
using AutoMapper;

namespace Asp.Net_Identity.App_Start
{
    public class MappingProfile  : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();
            Mapper.CreateMap<MemberShipTypeDto, MemberShipType>();

        }
    }
}