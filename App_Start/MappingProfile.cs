using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using blackBox.Models;
using blackBox.Dtos;

namespace blackBox.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Maps API outbound(server -> client) calls:
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Maps API inbound calls:
            //Mapper.CreateMap<CustomerDto, Customer>();
            //Mapper.CreateMap<MovieDto, Movie>();

            //Id identity error, ignore mapping of ids
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());


        }
    }
}