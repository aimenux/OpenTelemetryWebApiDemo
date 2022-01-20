using Api.Core;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        DbInitializer.Initialize(this);
    }

    public DbSet<Todo> Items { get; set; }
}