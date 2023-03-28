using AutoMapper;

using TodoApp.Api.Dtos;

namespace TodoApp.Api.Configurations;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<DataAccess.Todo, TodoDto>().ReverseMap();
        CreateMap<TodoForCreationDto, DataAccess.Todo>();
        CreateMap<TodoForUpdateDto, DataAccess.Todo>();
    }
}