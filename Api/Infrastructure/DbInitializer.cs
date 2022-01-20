using Api.Core;

namespace Api.Infrastructure;

public class DbInitializer
{
    public static void Initialize(TodoDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Items.Any())
        {
            return;
        }

        var items = new List<Todo>
        {
            new Todo { Id = 1, Name = "Working", IsComplete = false },
            new Todo { Id = 2, Name = "Playing", IsComplete = true },
            new Todo { Id = 3, Name = "Sleeping", IsComplete = false },
            new Todo { Id = 4, Name = "Shopping", IsComplete = true },
            new Todo { Id = 5, Name = "Traveling", IsComplete = false }
        };

        context.Items.AddRange(items);
        context.SaveChanges();
    }
}