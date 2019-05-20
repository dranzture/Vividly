using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vividly.Models;
using Vividly.DTOs;
namespace Vividly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain to dto

            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            //dto to domain
            
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(c => c.ID, opt => opt.Ignore()); ;
            Mapper.CreateMap<MovieDTO, Movie>().ForMember(c => c.ID, opt => opt.Ignore()); ;
        }       

    }
}