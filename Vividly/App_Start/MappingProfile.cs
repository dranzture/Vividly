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
            Mapper.CreateMap<Customer, CustomerDTO>().ForMember(c=>c.ID, opt=>opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Movie, MovieDTO>().ForMember(c => c.ID, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>();
        }       

    }
}