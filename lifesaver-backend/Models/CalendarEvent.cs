using System;
using System.ComponentModel.DataAnnotations;

namespace lifesaver_backend.Models;

public class CalendarEvent
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public DateTime StartTime { get; set; }
    
    [Required]
    public DateTime EndTime { get; set; }
    
    public bool IsAIRescheduled { get; set; } = false; 
}