using Microsoft.Extensions.DependencyInjection;
using TodoApp.DTO;
using TodoApp.Infrastructure.Interfaces;

//tests written with help of Copilot but carefully reviewed, checked and improved for correctness and reliability

namespace TodoApp.Tests
{
    public class TodoServiceTests : TestBase
    {
        private ITodoService GetService()
        {
            return ServiceProvider.GetRequiredService<ITodoService>();
        }

        [Fact]
        public async Task MarkTodoAsDone_UpdatesIsDone()
        {
            var service = GetService();
            var todo = await service.AddTodo(new AddTodoDTO { Title = "Test", Description = "Desc" });
            var result = await service.MarkTodoAsDone(todo.Id);
            Assert.NotNull(result);
            Assert.True(result.IsDone);
        }

        [Fact]
        public async Task DeleteTodo_RemovesTodo()
        {
            var service = GetService();
            var todo = await service.AddTodo(new AddTodoDTO { Title = "ToDelete", Description = "Desc" });
            var deleted = await service.DeleteTodoAsync(todo.Id);
            var afterDelete = await service.GetTodoWithId(todo.Id);
            Assert.True(deleted);
            Assert.Null(afterDelete);
        }

        [Fact]
        public async Task GetTodos_ReturnsAllTodos()
        {
            var service = GetService();
            await service.AddTodo(new AddTodoDTO { Title = "A", Description = "A" });
            await service.AddTodo(new AddTodoDTO { Title = "B", Description = "B" });
            var todos = await service.GetAllTodos();
            Assert.True(todos.Count >= 2);
        }
    }

}
