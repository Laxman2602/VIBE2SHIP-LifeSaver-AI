using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lifesaver_backend.Data;
using lifesaver_backend.Models;

namespace lifesaver_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask([FromBody] TaskItem task)
    {
        // 1. Verbose debugging: Print the state of the incoming object
        if (task == null) 
        {
            Console.WriteLine("DEBUG [TasksController]: Received null task from request body.");
            return BadRequest("Task object is null");
        }
        
        Console.WriteLine($"DEBUG [TasksController]: Attempting to save task: '{task.Title}' | Priority: {task.Priority} | Deadline: {task.Deadline}");
        
        // 2. Data persistence
        try 
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            Console.WriteLine("DEBUG [TasksController]: Successfully saved task to database.");
            return Ok(task);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"DEBUG [TasksController]: Database Error: {ex.Message}");
            return StatusCode(500, "Internal Server Error during database save.");
        }
    }
}