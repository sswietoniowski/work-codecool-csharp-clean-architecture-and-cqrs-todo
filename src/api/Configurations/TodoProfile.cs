using api.DataAccess;
using api.Dtos;

using AutoMapper;

namespace api.Configurations;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<Todo, TodoDto>().ReverseMap();
        CreateMap<TodoForCreationDto, Todo>();
        CreateMap<TodoForUpdateDto, Todo>();
    }
}