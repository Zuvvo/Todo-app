using System;
using TodoApp.DAL.Models;
using TodoApp.DTO;

namespace TodoApp.Infrastructure.Mappers
{
    public static class TodoMapper
    {
        public static TodoDTO ToDto(this Todo todo)
        {
            return new TodoDTO
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsDone = todo.IsDone
            };
        }

        public static Todo ToModel(this TodoDTO todoDto)
        {
            return new Todo
            {
                Id = todoDto.Id,
                Title = todoDto.Title,
                Description = todoDto.Description,
                IsDone = todoDto.IsDone
            };
        }

        public static Todo ToModel(this AddTodoDTO addTodoDTO)
        {
            return new Todo
            {
                Title = addTodoDTO.Title ?? string.Empty,
                Description = addTodoDTO.Description ?? string.Empty,
                IsDone = false
            };
        }
    }
}
