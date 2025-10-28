using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.DAL.Data;
using TodoApp.Infrastructure.Interfaces;
using TodoApp.Infrastructure.Services;

public class TestBase
{
    protected ServiceProvider ServiceProvider { get; private set; }

    public TestBase()
    {
        var services = new ServiceCollection();

        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("TestDb"));

        services.AddScoped<ITodoService, TodoService>();

        ServiceProvider = services.BuildServiceProvider();
    }
}