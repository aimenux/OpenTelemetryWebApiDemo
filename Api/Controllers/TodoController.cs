using Api.Helpers;
using Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoDbContext _dbContext;

        public TodoController(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            using var activity = OpenTelemetrySource.Instance.StartActivity();
            var items = await _dbContext.Items.ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            using var activity = OpenTelemetrySource.Instance.StartActivity();
            var item = await _dbContext.Items.FindAsync(id);
            return Ok(item);
        }
    }
}