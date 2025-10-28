using Microsoft.AspNetCore.Mvc;
using TodoApp.DTO;
using TodoApp.Infrastructure.Interfaces;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // GET: api/Todos
        [HttpGet]
        public async Task<ActionResult<List<TodoDTO>>> GetTodos()
        {
            var todos = await _todoService.GetAllTodos();

            if (todos.Count == 0)
            {
                return NotFound("No todos found.");
            }

            return Ok(todos);
        }

        // GET: api/Todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDTO>> GetTodo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }

            var todo = await _todoService.GetTodoWithId(id);
            if (todo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(todo);
        }

        // PUT: api/Todos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, UpdateTodoDTO updateTodoDTO)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }

            if (updateTodoDTO == null)
            {
                return BadRequest("Update data cannot be null.");
            }


            var updatedTodo = await _todoService.UpdateTodo(id, updateTodoDTO);
            if (updatedTodo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(updatedTodo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoDTO>> PostTodo(AddTodoDTO todo)
        {
            if (todo == null)
            {
                return BadRequest("Todo data cannot be null.");
            }

            if (string.IsNullOrEmpty(todo.Title))
            {
                return BadRequest("Title is required.");
            }

            TodoDTO result = await _todoService.AddTodo(todo);
            return Ok(result);
        }

        // DELETE: api/Todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }

            var isDeleted = await _todoService.DeleteTodoAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return NoContent();
        }

        [HttpPatch("{id}/done")]
        public async Task<IActionResult> MarkTodoAsDone(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }

            var updatedTodo = await _todoService.MarkTodoAsDone(id);
            if (updatedTodo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            return Ok(updatedTodo);
        }
    }
}
