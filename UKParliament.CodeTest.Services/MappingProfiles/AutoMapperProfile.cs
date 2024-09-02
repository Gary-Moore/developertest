using AutoMapper;
using UKParliament.CodeTest.Data.Entities;
using UKParliament.CodeTest.Data.DTO;

namespace UKParliament.CodeTest.Services.MappingProfiles
{
    // AutoMapperProfile inherits from Profile (class provided by AutoMapper)
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ignoring the id number when mapping objects
            CreateMap<CreateTodoRequestDTO, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateTodoRequestDTO, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CompleteTodoRequestDTO, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TodoItem, ToDoItemDTO>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}
