using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.DTO;

namespace TodoApp.Infrastructure.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoDTO>> GetAllTodos();
        Task<TodoDTO> AddTodo(AddTodoDTO addTodoDTO);
        Task<TodoDTO?> GetTodoWithId(int id);
        Task<TodoDTO?> UpdateTodo(int id, UpdateTodoDTO updateTodoDTO);
        Task<bool> DeleteTodoAsync(int id);
        Task<TodoDTO?> MarkTodoAsDone(int id);
    }
}
