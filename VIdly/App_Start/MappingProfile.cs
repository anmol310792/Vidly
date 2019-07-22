using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VIdly.Models;
using VIdly.Dtos;

namespace VIdly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}