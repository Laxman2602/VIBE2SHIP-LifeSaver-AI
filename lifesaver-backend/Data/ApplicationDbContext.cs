using Microsoft.EntityFrameworkCore;
using lifesaver_backend.Models;

namespace lifesaver_backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<AgentLog> AgentLogs { get; set; }
}