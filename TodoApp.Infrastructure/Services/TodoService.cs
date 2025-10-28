using Microsoft.EntityFrameworkCore;
using TodoApp.DAL.Data;
using TodoApp.DTO;
using TodoApp.Infrastructure.Interfaces;
using TodoApp.Infrastructure.Mappers;

namespace TodoApp.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;

        public TodoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoDTO>> GetAllTodos()
        {
            var todos = await _context.Todos.ToListAsync();
            return todos.Select(todo => todo.ToDto()).ToList();
        }

        public async Task<TodoDTO> AddTodo(AddTodoDTO addTodoDTO)
        {
            if (string.IsNullOrWhiteSpace(addTodoDTO.Title))
                throw new ArgumentException("Title cannot be empty.", nameof(addTodoDTO.Title));

            var todo = addTodoDTO.ToModel();
            _context.Add(todo);
            await _context.SaveChangesAsync();

            return todo.ToDto();
        }

        public async Task<TodoDTO?> GetTodoWithId(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            return todo == null ? null : todo.ToDto();
        }

        public async Task<TodoDTO?> UpdateTodo(int id, UpdateTodoDTO updateTodoDTO)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return null;

            if (!string.IsNullOrWhiteSpace(updateTodoDTO.Title))
                todo.Title = updateTodoDTO.Title;

            if (!string.IsNullOrWhiteSpace(updateTodoDTO.Description))
                todo.Description = updateTodoDTO.Description;

            if (updateTodoDTO.IsDone.HasValue)
                todo.IsDone = updateTodoDTO.IsDone.Value;

            await _context.SaveChangesAsync();

            return todo.ToDto();
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return false;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TodoDTO?> MarkTodoAsDone(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return null;

            if (todo.IsDone)
                return todo.ToDto();

            todo.IsDone = true;
            await _context.SaveChangesAsync();

            return todo.ToDto();
        }
    }
}
