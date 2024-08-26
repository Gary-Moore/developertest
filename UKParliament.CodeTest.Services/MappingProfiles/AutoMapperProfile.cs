using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Services.Contracts;

namespace UKParliament.CodeTest.Services.MappingProfiles
{
    // AutoMapperProfile inherits from Profile (class provided by AutoMapper)
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ignoring the id number when mapping objects
            CreateMap<CreateTodoRequest, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateTodoRequest, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
