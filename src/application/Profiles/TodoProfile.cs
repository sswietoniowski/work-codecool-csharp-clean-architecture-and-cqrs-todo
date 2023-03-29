using AutoMapper;

using TodoApp.Application.Dtos;
using TodoApp.Core;

namespace TodoApp.Application.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<Todo, TodoDto>().ReverseMap();
        CreateMap<TodoForCreationDto, Todo>();
        CreateMap<TodoForUpdateDto, Todo>();
    }
}